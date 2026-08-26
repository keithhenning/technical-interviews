import os, sys
ALLOW = {"data structures and algorithms/python/06_065.py",
         "data structures and algorithms/python/06_066.py"}
bad = []; scanned = 0; stale = []
for dp, dn, fn in os.walk("."):
    if ".git" in dp.split(os.sep): continue
    for f in sorted(fn):
        if not f.endswith(".py"): continue
        rel = os.path.relpath(os.path.join(dp, f), ".")
        scanned += 1
        try:
            compile(open(os.path.join(dp, f), "rb").read(), rel, "exec")
            if rel in ALLOW: stale.append(rel)
        except SyntaxError as e:
            if rel not in ALLOW: bad.append("%s:%s: %s" % (rel, e.lineno, e.msg))
print("scanned %d .py files" % scanned)
if scanned < 250: sys.exit("GATE BROKEN: scanned only %d files, expected ~295" % scanned)
for b in bad: print("FAIL", b)
for s in stale: print("STALE ALLOWLIST ENTRY (now compiles, remove it):", s)
sys.exit(1 if bad or stale else 0)
