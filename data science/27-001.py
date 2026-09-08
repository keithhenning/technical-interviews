import numpy as np

def remove_threshold(scores, labels, precision_floor=0.99):
    order = np.argsort(-scores)
    tp = np.cumsum(labels[order])
    precision = tp / (np.arange(len(order)) + 1)
    ok = np.where(precision >= precision_floor)[0]
    return scores[order][ok[-1]] if len(ok) else 1.01   # nothing qualifies

def review_threshold(priority, capacity):
    # priority = p_violation * severity_weight * log1p(author_reach)
    if len(priority) <= capacity:
        return 0.0
    return np.sort(priority)[-capacity]
