import numpy as np
from sklearn.metrics import precision_recall_curve, average_precision_score

def threshold_for_top_k(scores, k):
    return np.sort(scores)[-k]

def cost_threshold(c_fn=4000, c_fp=25):
    return c_fp / (c_fn + c_fp)

thr_cap = threshold_for_top_k(val_scores, k=1000)
thr_cost = cost_threshold()
for name, thr in [("capacity", thr_cap), ("cost", thr_cost)]:
    flagged = val_scores >= thr
    prec = y_val[flagged].mean()
    rec = y_val[flagged].sum() / y_val.sum()
    print(f"{name}: thr={thr:.4f} flagged={flagged.sum()} P={prec:.3f} R={rec:.3f}")
print("PR-AUC", round(average_precision_score(y_val, val_scores), 4))
