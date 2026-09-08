from sklearn.cluster import KMeans
from sklearn.metrics import adjusted_rand_score
import numpy as np

def stability(X, k, n_boot=10, seed=0):
    rng = np.random.default_rng(seed)
    labels = []
    for _ in range(n_boot):
        idx = rng.choice(len(X), size=len(X) // 2, replace=False)
        km = KMeans(n_clusters=k, n_init=10, random_state=int(rng.integers(1e6)))
        km.fit(X[idx])
        labels.append(km.predict(X))  # assign the full population
    scores = [
        adjusted_rand_score(labels[i], labels[j])
        for i in range(n_boot) for j in range(i + 1, n_boot)
    ]
    return float(np.mean(scores)), float(np.min(scores))
