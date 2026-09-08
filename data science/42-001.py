import numpy as np

def init_pp(X, k, rng):
    centers = [X[rng.integers(len(X))]]
    for _ in range(k - 1):
        d2 = np.min(((X[:, None, :] - np.array(centers)[None]) ** 2).sum(2), axis=1)
        centers.append(X[rng.choice(len(X), p=d2 / d2.sum())])
    return np.array(centers)

def kmeans(X, k, n_iter=100, seed=0):
    rng = np.random.default_rng(seed)
    centers = init_pp(X, k, rng)
    for _ in range(n_iter):
        d = ((X[:, None, :] - centers[None, :, :]) ** 2).sum(axis=2)   # (n, k)
        labels = d.argmin(axis=1)
        new_centers = centers.copy()
        for j in range(k):
            if (labels == j).any():                # empty cluster keeps its old center
                new_centers[j] = X[labels == j].mean(axis=0)
        if np.allclose(new_centers, centers):
            break
        centers = new_centers
    inertia = d[np.arange(len(X)), labels].sum()
    return centers, labels, inertia
