"""Syntax gate for the C# sources, the sibling of tools/syntax_gate.py.

WHY THIS EXISTS. syntax_gate.py opens with `if not f.endswith(".py"): continue`. It scans 296
Python files and ignores 278 C#, 237 C++ and 276 Java, which is 27 percent of the published
source going unchecked. That is how #143's five broken C# files shipped and stayed shipped, one
of which was Java saved under a .cs extension.

WHAT IT CHECKS: that every .cs file in the repository PARSES. Nothing else. It runs Roslyn's
parser through tools/csharp_parse.cs and reads the diagnostics the parser itself produced, rather
than filtering a compiler's output by error number. Read that file's header for why a compiler
cannot do this job: a whole-set compile reports 46 errors and hides 464, and the 46 look like the
known book convention.

WHAT IT DOES NOT COVER, stated here so a green run is not read as more than it is:

  - It does not check that the code is CORRECT, or that it compiles, or that it runs. A snippet
    that parses can still reference a type that does not exist, loop forever or return the wrong
    answer. Parsing is the floor, not the bar.
  - It does not check C++ or Java, which are still unguarded, and it is NOT the pattern for them.
    Both were measured on 31 August 2026 and neither is gateable by compiling: 112 of 237 .cpp
    files fail -fsyntax-only and forcing 21 standard headers only reaches 70, the rest referencing
    types the book defines in prose. Java is worse -- roughly 100 files hit the public-class
    filename rule because the book numbers files 03_001.java while the class is Main, 102 are bare
    method snippets, and after neutralising three conventions 89 still fail with 43 of those
    "cannot find symbol". A gate that shows 70 or 89 red files on day one is a gate somebody
    switches off in a week. If those are ever gated it has to be by a PARSER, the way this file
    does it, and that is a separate piece of work nobody has scoped.
  - It does not check the four other languages by name, nor any file that is not .cs.
  - CS0106 is the one diagnostic it forgives, for the 42 files that are bare methods by book
    convention, and it forgives them only after re-parsing each one wrapped in a class. See
    csharp_parse.cs for what that argument does and does not establish: the hole it was written to
    close turned out not to be openable, because Roslyn pairs CS0106 with CS8803 whenever a class
    was closed early. The exemption is narrower than it looks, and it is still the part of this
    gate most likely to be wrong.

HOW IT REFUSES TO PASS VACUOUSLY. Three separate ways, because a gate that reads nothing and a
gate that finds nothing print the same thing:

  1. A KNOWN-BAD CANARY is parsed on every run, from a temporary directory outside the repository.
     If the canary is not caught, the gate exits non-zero saying so, whatever the real files did.
  2. The file count has a floor, matching syntax_gate.py's convention.
  3. The helper reports how many files it actually read, and that number is compared against the
     number handed to it. A mismatch is a gate failure.

The third one is not decoration. The first attempt at this gate passed paths on the command line;
the tree is `data structures and algorithms` WITH SPACES, every path word-split, csc reported
CS2001 for all 279 and the run produced zero syntax errors from having parsed nothing at all.
Paths are handed over one per line in a list file now, which is immune to splitting by
construction rather than by quoting carefully.

Usage:  python3 tools/csharp_gate.py
"""
import glob
import os
import subprocess
import sys
import tempfile

# Files known to be broken and deliberately tolerated, same convention as syntax_gate.py: list the
# file rather than switch the gate off, and the gate tells you when an entry stops being needed.
ALLOW = set()

# A DATED OBSERVATION, NOT A CONSTRAINT. Measured 31 August 2026: 278 .cs files under the book
# directories plus this gate's own helper, which is a .cs file and is deliberately not exempt
# from its own check.
#
# It appears only in an error message and it drifts every time the book grows -- this number
# moved from 278 to 279 within a day of being written, when the helper was added, and 8b3c480
# added a .cpp and removed a .java in the same window. A number in a message that slowly stops
# being true is a small lie nobody is accountable for, so it is labelled with the date it was
# true rather than presented as a rule.
#
# FLOOR below is different and must NOT get the same treatment: its whole job is to catch "the
# walk found nothing", and a floor derived from the current tree always equals the current
# count and could therefore never fire. Hand-set and deliberately loose is correct there.
EXPECTED_FILES = 279  # observed 2026-08-31
FLOOR = 250

CANARY = """// Deliberately unparseable. Parsed on every run of tools/csharp_gate.py.
// If the gate does not report this file, the gate read nothing and its silence means nothing.
class CanaryDoesNotParse
{
    void M()
    {
        if (true) { }
    // the closing brace of M() and of the class are both missing, on purpose
"""


def die(msg):
    sys.exit("GATE BROKEN: " + msg)


def sdk_dirs():
    """Where the .NET SDK actually is, asked of dotnet rather than guessed.

    The first version of this globbed /usr/lib/dotnet/sdk, which is where Debian and Ubuntu put it
    and where it is on the machine this gate was written on. GitHub's ubuntu-latest runner with
    actions/setup-dotnet puts it in /usr/share/dotnet, so that version would have found nothing and
    failed CI on its first run: a check correct for the environment its author imagined and wrong
    for the one it runs in. `dotnet --list-sdks` prints "8.0.130 [/usr/lib/dotnet/sdk]", so the
    location is available for the asking. The old guesses stay as fallbacks and go last.
    """
    found = []
    try:
        out = subprocess.run(["dotnet", "--list-sdks"], capture_output=True, text=True)
        for line in out.stdout.splitlines():
            if "[" in line and line.rstrip().endswith("]"):
                version, root = line.split(" [", 1)
                found.append(os.path.join(root.rstrip("]").rstrip(), version.strip()))
    except FileNotFoundError:
        die("`dotnet` is not on PATH. Install the .NET SDK, or in CI use actions/setup-dotnet.")
    found += sorted(glob.glob("/usr/lib/dotnet/sdk/*")) + \
        sorted(glob.glob("/usr/share/dotnet/sdk/*")) + \
        sorted(glob.glob(os.path.expanduser("~/.dotnet/sdk/*")))
    return found


def roslyn_dir():
    """The Roslyn shipped inside the .NET SDK.

    Referencing the SDK's own compiler libraries rather than a NuGet package keeps this runnable
    with no network and no restore step. It is a private path and it can move between SDK versions,
    so a miss is a loud failure and never a skipped check.
    """
    for sdk in sdk_dirs():
        cand = os.path.join(sdk, "Roslyn", "bincore")
        if os.path.exists(os.path.join(cand, "Microsoft.CodeAnalysis.CSharp.dll")):
            return cand
    die("no .NET SDK Roslyn found. Asked `dotnet --list-sdks` and checked the usual install roots. "
        "Install the .NET SDK, or in CI use actions/setup-dotnet.")


def ref_assemblies():
    """The full reference assembly set.

    A bare netstandard.dll is not enough and the failure is misleading: known-good files are
    rejected for types that do exist. The parser needs none of this, but the helper is COMPILED
    against it, so it is needed once at build time.
    """
    # Relative to whichever dotnet root actually holds the SDK, for the reason in sdk_dirs().
    roots = {os.path.dirname(os.path.dirname(sdk)) for sdk in sdk_dirs()}
    packs = []
    for root in sorted(roots):
        packs += sorted(glob.glob(os.path.join(root, "packs", "Microsoft.NETCore.App.Ref",
                                               "*", "ref", "net*") + os.sep))
    if not packs:
        die("no Microsoft.NETCore.App.Ref pack found under any dotnet root (%s)."
            % ", ".join(sorted(roots) or ["none"]))
    dlls = sorted(glob.glob(os.path.join(packs[-1], "*.dll")))
    if len(dlls) < 50:
        die("reference pack %s holds only %d assemblies, expected ~163. A partial ref set rejects "
            "known-good code, which looks like a finding." % (packs[-1], len(dlls)))
    return dlls


def build_helper(bincore, workdir):
    """Compile tools/csharp_parse.cs into workdir and return the assembly path."""
    out = os.path.join(workdir, "ParseOnly.dll")
    rsp = os.path.join(workdir, "build.rsp")
    args = ["-nologo", "-t:exe", "-nostdlib", "-out:" + out,
            "-r:" + os.path.join(bincore, "Microsoft.CodeAnalysis.dll"),
            "-r:" + os.path.join(bincore, "Microsoft.CodeAnalysis.CSharp.dll")]
    args += ["-r:" + d for d in ref_assemblies()]
    args += [os.path.join("tools", "csharp_parse.cs")]
    # One argument per line, so a path containing a space cannot be split.
    with open(rsp, "w") as fh:
        fh.write("\n".join('"%s"' % a if a.startswith("-r:") or not a.startswith("-") else a
                           for a in args) + "\n")
    r = subprocess.run(["dotnet", os.path.join(bincore, "csc.dll"), "@" + rsp],
                       capture_output=True, text=True)
    if r.returncode != 0 or not os.path.exists(out):
        die("could not build tools/csharp_parse.cs:\n" + (r.stdout or "") + (r.stderr or ""))
    with open(os.path.join(workdir, "ParseOnly.runtimeconfig.json"), "w") as fh:
        fh.write('{"runtimeOptions":{"tfm":"net8.0","framework":'
                 '{"name":"Microsoft.NETCore.App","version":"8.0.0"}}}\n')
    for dll in ("Microsoft.CodeAnalysis.dll", "Microsoft.CodeAnalysis.CSharp.dll"):
        src, dst = os.path.join(bincore, dll), os.path.join(workdir, dll)
        with open(src, "rb") as a, open(dst, "wb") as b:
            b.write(a.read())
    return out


def main():
    sources = []
    for dirpath, _dirnames, filenames in os.walk("."):
        if ".git" in dirpath.split(os.sep):
            continue
        for f in sorted(filenames):
            if f.endswith(".cs"):
                sources.append(os.path.relpath(os.path.join(dirpath, f), "."))
    sources.sort()
    print("scanned %d .cs files" % len(sources))
    if len(sources) < FLOOR:
        die("found only %d .cs files, expected ~%d" % (len(sources), EXPECTED_FILES))

    with tempfile.TemporaryDirectory() as workdir:
        bincore = roslyn_dir()
        helper = build_helper(bincore, workdir)

        canary = os.path.join(workdir, "CanaryDoesNotParse.cs")
        with open(canary, "w") as fh:
            fh.write(CANARY)

        listfile = os.path.join(workdir, "sources.txt")
        with open(listfile, "w") as fh:
            fh.write("\n".join(sources + [canary]) + "\n")

        r = subprocess.run(["dotnet", helper, listfile], capture_output=True, text=True)
        if r.returncode != 0:
            die("the parse helper exited %d:\n%s" % (r.returncode, r.stderr))

        reported = [ln for ln in r.stderr.splitlines() if ln.startswith("parsed ")]
        if len(reported) != 1:
            die("the parse helper did not report how many files it read; stderr was:\n" + r.stderr)
        read = int(reported[0].split()[1])
        if read != len(sources) + 1:
            die("handed the helper %d files and it read %d. The two must agree or this gate is "
                "reporting on a set it did not measure." % (len(sources) + 1, read))

        findings, canary_caught = [], False
        for line in r.stdout.splitlines():
            path, lineno, ident, stage, message = line.split("\t", 4)
            if path == canary:
                canary_caught = True
                continue
            findings.append((path, lineno, ident, stage, message))

    if not canary_caught:
        die("the known-bad canary was NOT reported. Whatever the files above did, this run proves "
            "nothing: three checks in this estate have reported clean while reading nothing.")

    bad = [f for f in findings if f[0] not in ALLOW]
    broken = {f[0] for f in findings}
    stale = sorted(a for a in ALLOW if a not in broken)

    for path, lineno, ident, stage, message in bad:
        detail = message if stage == "parse" else message + "  [still broken once wrapped in a class]"
        print("FAIL %s:%s: %s: %s" % (path, lineno, ident, detail))
    for s in stale:
        print("STALE ALLOWLIST ENTRY (now parses, remove it):", s)
    sys.exit(1 if bad or stale else 0)


if __name__ == "__main__":
    main()
