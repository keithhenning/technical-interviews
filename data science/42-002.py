import numpy as np

def logistic_regression(X, y, lr=0.1, n_iter=1000, l2=0.0):
    n, p = X.shape
    Xb = np.hstack([np.ones((n, 1)), X])         # bias column
    w = np.zeros(p + 1)
    for _ in range(n_iter):
        z = Xb @ w
        prob = 1 / (1 + np.exp(-z))
        grad = Xb.T @ (prob - y) / n              # d(mean log loss)/dw
        grad[1:] += l2 * w[1:]                    # don't shrink the bias
        w -= lr * grad
    return w

def predict_proba(X, w):
    return 1 / (1 + np.exp(-(np.hstack([np.ones((len(X), 1)), X]) @ w)))
