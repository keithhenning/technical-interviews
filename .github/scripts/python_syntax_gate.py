#!/usr/bin/env python3
"""Syntax gate for the Python code in this repository.

Walks the repository from the current working directory, compiles every
.py file it finds, and fails the build if any file does not parse. It is
deliberately small: no dependencies beyond the standard library, no
install step required in CI.

Three properties are load-bearing and should not be simplified away:

  - A FLOOR CHECK on the number of files scanned. A syntax gate run from
    the wrong working directory (or against an empty checkout) finds zero
    broken files and reports success, which is a worse outcome than
    finding real breakage: a check that passes while proving nothing.
    This gate refuses to pass if it cannot see roughly the expected size
    of the corpus.
  - A NAMED ALLOWLIST rather than a blanket skip. Two files in this repo
    are intentionally incomplete exercise skeletons (their bodies are
    comments telling the reader what to implement); they are exempted by
    name, and everything else is held to the rule.
  - A STALE-ALLOWLIST CHECK. If an allowlisted file starts compiling
    (for example because someone filled in the exercise), the gate FAILS
    and says which entry to remove. An allowlist nobody prunes is how a
    permanent exemption is born.

Run from the repository root.
"""

import os
import sys

ALLOW = {
    "data structures and algorithms/python/06_065.py",
    "data structures and algorithms/python/06_066.py",
}

EXPECTED_MINIMUM_FILES = 250  # ~295 at time of writing; adjust only if the corpus shrinks for real

bad = []
stale = []
scanned = 0

for dirpath, dirnames, filenames in os.walk("."):
    if ".git" in dirpath.split(os.sep):
        continue
    for filename in sorted(filenames):
        if not filename.endswith(".py"):
            continue
        rel = os.path.relpath(os.path.join(dirpath, filename), ".")
        scanned += 1
        try:
            compile(open(os.path.join(dirpath, filename), "rb").read(), rel, "exec")
            if rel in ALLOW:
                stale.append(rel)
        except SyntaxError as e:
            if rel not in ALLOW:
                bad.append("%s:%s: %s" % (rel, e.lineno, e.msg))

print("scanned %d .py files" % scanned)

if scanned < EXPECTED_MINIMUM_FILES:
    sys.exit(
        "GATE BROKEN: scanned only %d files, expected at least %d. "
        "This usually means the gate ran from the wrong directory."
        % (scanned, EXPECTED_MINIMUM_FILES)
    )

for b in bad:
    print("FAIL", b)
for s in stale:
    print("STALE ALLOWLIST ENTRY (now compiles, remove it from ALLOW):", s)

sys.exit(1 if bad or stale else 0)
