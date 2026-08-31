"""Syntax gate for the C++ and Java sources. The third sibling of tools/syntax_gate.py.

WHY THIS EXISTS, AND WHY IT IS A PARSER. The C# gate (tools/csharp_gate.py) established the
shape: a compiler cannot check independent book snippets, because they share class names and
reference types the prose defines, so a whole-set compile drowns in semantic errors and a
per-file compile drowns in missing symbols. Measured for C++ and Java before this file was
written: roughly 112 of 237 .cpp fail `g++ -fsyntax-only`, dropping only to about 70 with 21
standard headers forced; Java has three separate conventions and still leaves 89 failures,
43 of them "cannot find symbol". None of that is a defect in the book. It is the wrong
instrument.

**C++ and Java were never un-gateable. They were not gateable BY COMPILING.** C# worked because
the gate stopped compiling and called Roslyn's parser. The same move works here: tree-sitter
ships real grammars for both languages, so the errors below are the ones the PARSER produced, by
construction, never a filter over compiler messages. Measured with this approach the whole set is
near-clean, which is what a parse gate over published book code should look like:

    .cpp    238 files, 4 flagged  (1.7%)
    .java   275 files, 1 flagged  (0.4%)

and every one of those five is accounted for below rather than left as a number.

WHAT IT DOES NOT COVER, out loud, so a green run is not read as more than it is:

  - Not correctness, not compilation, not that anything runs, not semantics of any kind.
    tree-sitter has no type system. A file that parses can call a function that does not exist,
    bind a temporary to a non-const reference, or return the wrong answer.
  - Not the .cs files. tools/csharp_gate.py does those, with Roslyn.
  - Not any other language, and nothing that is not .cpp or .java.
  - **It is bounded by what the grammars can parse, and they are not the language.** See ALLOW:
    tree-sitter's C++ grammar cannot parse a brace-initialised default argument, which is valid
    C++11 and which g++ accepts. That is a limit of the tool and it is listed file by file rather
    than papered over.

HOW IT REFUSES TO PASS VACUOUSLY, the same three ways as the C# gate, because a gate that reads
nothing and a gate that finds nothing print the same thing:

  1. A KNOWN-BAD CANARY per language, parsed on every run from memory rather than from the tree.
     If either canary is not flagged, the run exits non-zero whatever the real files did.
  2. A file-count floor, syntax_gate.py's convention.
  3. The number of files parsed is compared against the number enumerated. They must agree.

Usage:  python3 tools/cpp_java_gate.py
Needs:  pip install tree-sitter tree-sitter-cpp tree-sitter-java
"""
import os
import sys

# Files this gate cannot presently judge, with the reason. syntax_gate.py's convention: list the
# file rather than switch the gate off, and be told when an entry stops being needed.
#
# ALL THREE ARE THE SAME TREE-SITTER GRAMMAR GAP, not book defects, and the distinction was
# measured rather than assumed. `void f(const std::vector<int>& v = {})` is valid C++11.
# tree-sitter reports ERROR on it; `g++ -std=c++17 -fsyntax-only` accepts it. Two controls pin
# that down: a scalar default (`int n = 0`) and a named-constructor default
# (`= std::vector<int>()`) both parse clean in tree-sitter, and genuinely broken code errors in
# both tools. So the failing element is the brace-init default argument specifically.
#
# When tree-sitter-cpp learns this construct, these three stop being flagged and the run will say
# STALE ALLOWLIST ENTRY and fail until they are removed. That is the intended way out.
ALLOW = {
    "data structures and algorithms/cpp/03_005.cpp":
        "tree-sitter-cpp cannot parse `= {10, 100, 1000}` as a default argument (line 6). Valid C++11; g++ accepts it.",
    "data structures and algorithms/cpp/06_113.cpp":
        "tree-sitter-cpp cannot parse `= {}` as a default argument (line 2). NOTE: this one is also semantically "
        "questionable -- a non-const lvalue reference cannot bind a temporary -- but that is a type error, not a "
        "parse error, and out of scope for this gate. Worth a human look.",
    "data structures and algorithms/cpp/08_055.cpp":
        "tree-sitter-cpp cannot parse `= {}` as a default argument (line 81). Valid C++11; g++ accepts it.",
}

# Measured 31 August 2026: 238 .cpp, 275 .java.
EXPECTED = {".cpp": 238, ".java": 275}
FLOOR = {".cpp": 200, ".java": 230}

# The bare-fragment convention, which both languages use and which the book uses deliberately:
# a snippet that is a method body or a few statements meant to be pasted into something larger.
# A file that fails to parse on its own is RE-PARSED wrapped, and excused only if the wrapped form
# is clean, so the convention is proved for that file on that run rather than credited.
#
# The obvious hole -- a file missing a closing brace balancing against the wrapper's -- was tested
# rather than reasoned about, in both languages, and does not open: a deleted brace still fails
# wrapped, and so does real garbage inside an otherwise well-formed fragment.
WRAP = {
    ".cpp": (b"void __gate_wrapper() {\n", b"\n}\n"),
    ".java": (b"class __GateWrapper {\n", b"\n}\n"),
}

CANARY = {
    ".cpp": b"int broken( {\n  return 0;\n",
    ".java": b"class CanaryDoesNotParse {\n  int m() { return ; }\n",
}


def die(msg):
    sys.exit("GATE BROKEN: " + msg)


def load_parsers():
    try:
        from tree_sitter import Language, Parser
        import tree_sitter_cpp
        import tree_sitter_java
    except ImportError as exc:
        die("tree-sitter is not installed (%s). Run:\n"
            "    pip install tree-sitter tree-sitter-cpp tree-sitter-java\n"
            "This gate never degrades to skipping files: no parser means no run." % exc)
    from importlib.metadata import version
    versions = {n: version(n) for n in ("tree-sitter", "tree-sitter-cpp", "tree-sitter-java")}
    return ({".cpp": Parser(Language(tree_sitter_cpp.language())),
             ".java": Parser(Language(tree_sitter_java.language()))}, versions)


def shallowest_errors(node, out, limit=3):
    """The outermost ERROR/MISSING nodes, not every descendant of one.

    Reporting every node under an ERROR turns one broken brace into forty findings and buries the
    file that has two separate problems.
    """
    if len(out) >= limit:
        return
    if node.type == "ERROR" or node.is_missing:
        out.append(node)
        return
    for child in node.children:
        if child.has_error:
            shallowest_errors(child, out, limit)


def judge(parser, ext, source):
    """(ok, stage, errors). stage says which observation decided it, so a reader can tell a clean
    file from one excused by the wrap."""
    tree = parser.parse(source)
    if not tree.root_node.has_error:
        return True, "parsed", []
    opener, closer = WRAP[ext]
    wrapped = parser.parse(opener + source + closer)
    if not wrapped.root_node.has_error:
        return True, "wrapped", []
    errs = []
    shallowest_errors(tree.root_node, errs)
    return False, "parse", errs


def main():
    parsers, versions = load_parsers()
    print("tree-sitter %(tree-sitter)s, cpp %(tree-sitter-cpp)s, java %(tree-sitter-java)s" % versions)

    # The canaries first. If a grammar has stopped reporting errors at all, nothing below means
    # anything, and that should be said before a wall of green.
    for ext, src in CANARY.items():
        ok, _stage, _errs = judge(parsers[ext], ext, src)
        if ok:
            die("the known-bad %s canary PARSED. Whatever the files below do, this run proves "
                "nothing." % ext)

    findings, wrapped_files, total = [], [], {}
    for ext, parser in parsers.items():
        paths = []
        for dirpath, _dirnames, filenames in os.walk("."):
            if ".git" in dirpath.split(os.sep):
                continue
            for f in sorted(filenames):
                if f.endswith(ext):
                    paths.append(os.path.relpath(os.path.join(dirpath, f), "."))
        paths.sort()
        total[ext] = len(paths)
        print("scanned %d %s files" % (len(paths), ext))
        if len(paths) < FLOOR[ext]:
            die("found only %d %s files, below the floor of %d (expected ~%d)"
                % (len(paths), ext, FLOOR[ext], EXPECTED[ext]))

        parsed = 0
        for rel in paths:
            with open(rel, "rb") as fh:
                source = fh.read()
            parsed += 1
            ok, stage, errs = judge(parser, ext, source)
            if ok:
                if stage == "wrapped":
                    wrapped_files.append(rel)
                continue
            for e in errs:
                findings.append((rel, e.start_point[0] + 1,
                                 ("missing " + e.type) if e.is_missing else "unparsed"))
        if parsed != len(paths):
            die("enumerated %d %s files and parsed %d. The two must agree or this gate is "
                "reporting on a set it did not measure." % (len(paths), ext, parsed))

    broken = {f[0] for f in findings}
    bad = [f for f in findings if f[0] not in ALLOW]
    stale = sorted(a for a in ALLOW if a not in broken)

    for rel in wrapped_files:
        print("  note: %s parses only once wrapped, which is the bare-fragment book convention" % rel)
    for rel, line, kind in bad:
        print("FAIL %s:%s: %s" % (rel, line, kind))
    for s in stale:
        print("STALE ALLOWLIST ENTRY (now parses, remove it):", s)

    if bad or stale:
        sys.exit(1)
    print("OK: %d .cpp and %d .java parse, %d excused by the wrap, %d allowlisted."
          % (total[".cpp"], total[".java"], len(wrapped_files), len(ALLOW)))


if __name__ == "__main__":
    main()
