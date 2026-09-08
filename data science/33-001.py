import numpy as np

def precision_at_k(y_true, scores, k):
    top = np.argsort(-scores)[:k]
    return y_true[top].mean()

def recall_at_k(y_true, scores, k):
    top = np.argsort(-scores)[:k]
    return y_true[top].sum() / y_true.sum()

k = 600
for name, s in [("internal", s_internal), ("vendor", s_vendor)]:
    p, r = precision_at_k(y_test, s, k), recall_at_k(y_test, s, k)
    print(f"{name}: P@{k}={p:.3f} R@{k}={r:.3f} fraud caught={int(p*k)}")
