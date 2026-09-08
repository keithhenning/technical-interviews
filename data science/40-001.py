import numpy as np

rng = np.random.default_rng(7)
n = 1_000_000
is_fraud = rng.random(n) < 0.01                      # 1% base rate
flagged = np.where(is_fraud,
                   rng.random(n) < 0.95,             # sensitivity
                   rng.random(n) < 0.02)             # false positive rate
print(f"flagged: {flagged.sum():,}")
print(f"P(fraud | flagged) = {is_fraud[flagged].mean():.3f}")   # ~0.324
