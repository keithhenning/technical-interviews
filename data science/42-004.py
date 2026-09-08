import numpy as np

def stratified_split(X, y, test_size=0.2, seed=0):
    rng = np.random.default_rng(seed)
    test_idx = []
    for cls in np.unique(y):
        members = np.flatnonzero(y == cls)
        rng.shuffle(members)
        n_test = int(round(test_size * len(members)))
        test_idx.extend(members[:n_test])
    test_mask = np.zeros(len(y), dtype=bool)
    test_mask[test_idx] = True
    return X[~test_mask], X[test_mask], y[~test_mask], y[test_mask]
