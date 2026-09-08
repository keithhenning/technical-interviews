import numpy as np

def bootstrap_ci(x, stat=np.mean, n_boot=10_000, alpha=0.05, seed=0):
    rng = np.random.default_rng(seed)
    x = np.asarray(x)
    idx = rng.integers(0, len(x), size=(n_boot, len(x)))   # resample WITH replacement
    boot_stats = stat(x[idx], axis=1)
    lo, hi = np.percentile(boot_stats, [100 * alpha / 2, 100 * (1 - alpha / 2)])
    return stat(x), lo, hi
