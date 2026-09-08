import numpy as np

def flips_until(pattern, trials=100_000, seed=0):
    rng = np.random.default_rng(seed)
    total = 0
    for _ in range(trials):
        seq = ""
        while not seq.endswith(pattern):
            seq += "H" if rng.random() < 0.5 else "T"
        total += len(seq)
    return total / trials

print("HH:", flips_until("HH"))    # ~6.0
print("HT:", flips_until("HT"))    # ~4.0
