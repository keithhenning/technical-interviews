#!/usr/bin/env python3
"""Detect the fixed-width export signature that damaged the system-design book (#289, #360).

WHAT THIS IS FOR, and why it is not a style check.

In February 2026 the entire system-design book was exported through a fixed-width text formatter
that wrapped at 62 columns without knowing Python indentation is syntax. It damaged 31 of 47 Python
files -- against 1 of 248 in the DSA book, which went through a different export path. The files
were repaired by hand under #226/#288 and every one of them compiles today.

**THE EXPORT PATH WAS NEVER FIXED.** It is not on this machine and not in the estate (#360, and I
searched again on 1 September 2026 before writing this). So the next export through the same tool
re-damages, and the only thing standing between that and another six months of broken published
code is whether anyone notices.

`syntax_gate.py` and `cpp_java_gate.py` would catch the re-damage in .py, .cpp and .java. THEY ARE
NOT ENOUGH, for a reason #238 demonstrated on 31 August: a .txt file containing Python is invisible
to a gate that walks .py. The February damage showed the same 62-column wrap in .txt PROSE -- it
broke a sentence mid-phrase -- and in .sql, .yaml and .lua. Those are not parsed by anything and
never will be.

So this check does not look for broken syntax. **It looks for the fingerprint itself**, which is
present in every file type the formatter touched, whether or not the result happens to still parse.

THE FINGERPRINT. A fixed-width formatter leaves a distribution no human leaves: a hard ceiling,
with nothing above it, across every file type in a directory. #289 measured it exactly -- every one
of the 2,218 lines under `system design/` was at most 62 characters, with a single 63-character
.lua exception, while DSA python ran to 99, cpp to 111, java to 104 and cs to 105.

So the assertion is inverted from what a linter would do: this fails when the longest line is TOO
SHORT. A book directory whose maximum line length collapses to a low ceiling has been through a
wrapper, and that is worth a human look even if everything still compiles.

WHAT IT DELIBERATELY DOES NOT DO. It does not enforce a maximum. It does not care about style. A
file may be any width. It fires only when a whole directory's ceiling drops, which is a property of
a MACHINE having rewritten the tree rather than of anyone's editing.
"""

import pathlib
import sys

ROOT = pathlib.Path(__file__).resolve().parent.parent

# Content directories whose line-length ceiling is meaningful. Each is a book export.
WATCHED = [
    "system design",
    "data structures and algorithms",
]

# Extensions the formatter touched. Deliberately WIDER than any parser gate's set: the whole point
# is that .txt, .sql and .yaml carry the fingerprint and no parser will ever read them.
SUFFIXES = {".py", ".txt", ".cpp", ".java", ".cs", ".sql", ".yaml", ".yml", ".lua", ".json", ".md"}

# The floor a healthy directory's LONGEST line must clear.
#
# Measured 1 September 2026: system design 91, data structures and algorithms 111. The February
# damage capped system design at 62 (one 63-character exception). 75 sits well above the damage and
# well below both healthy values, so it catches a recurrence of the observed cap with room on either
# side. It is a hand-set threshold and is deliberately NOT derived from the current tree: a floor
# computed from what is there now always passes, which is the same reason syntax_gate.py's file
# floor is hand-set.
MIN_LONGEST_LINE = 75


def longest_line(directory: pathlib.Path) -> tuple[int, int, str]:
    """(longest line length, files read, where the longest line was)."""
    longest, files, where = 0, 0, ""
    for path in sorted(directory.rglob("*")):
        if not path.is_file() or path.suffix not in SUFFIXES:
            continue
        files += 1
        try:
            text = path.read_text(errors="replace")
        except OSError:
            continue
        for i, line in enumerate(text.splitlines(), 1):
            if len(line) > longest:
                longest, where = len(line), f"{path.relative_to(ROOT)}:{i}"
    return longest, files, where


def main() -> int:
    failures = 0
    for name in WATCHED:
        directory = ROOT / name
        if not directory.is_dir():
            # An absent watched directory is a loud failure, never a skip. A check that quietly
            # ranges over nothing is the defect this estate has hit most often.
            print(f"GATE BROKEN: watched directory {name!r} does not exist. This check cannot")
            print("range over a tree that is not there, and reporting OK would be a clean sweep")
            print("over an empty set.")
            failures += 1
            continue

        longest, files, where = longest_line(directory)

        if files == 0:
            print(f"GATE BROKEN: {name!r} holds no files of any watched type. Read 0 files.")
            failures += 1
            continue

        if longest < MIN_LONGEST_LINE:
            print(f"FAIL  {name}: longest line is {longest} chars across {files} files.")
            print(f"      That is below the {MIN_LONGEST_LINE}-character floor, and a whole directory")
            print("      whose ceiling collapses has been through a fixed-width formatter rather than")
            print("      edited. This is the #289 signature: February 2026's export capped this tree at")
            print("      62 and silently broke 31 of 47 Python files by destroying indentation.")
            print("      The export path was never fixed (#360). Check what produced this tree before")
            print("      trusting anything in it, including files that still compile.")
            failures += 1
        else:
            print(f"ok    {name}: longest line {longest} chars over {files} files ({where})")

    print(f"\nchecked {len(WATCHED)} book directories against a {MIN_LONGEST_LINE}-char floor")
    if failures:
        print("\nThis check does NOT enforce a maximum width and has no opinion about style.")
        print("It fails only when a directory's longest line is too SHORT, which is a property of a")
        print("machine having rewritten the tree.")
    return 1 if failures else 0


if __name__ == "__main__":
    sys.exit(main())
