import numpy as np
import pandas as pd
from sklearn.metrics import roc_auc_score

def leak_scan(X: pd.DataFrame, y: pd.Series, thresh=0.85):
    rows = []
    for col in X.columns:
        x = X[col]
        if x.dtype.kind in "biuf" and x.nunique() > 1:
            filled = x.fillna(x.median())
            auc = roc_auc_score(y, filled)
            auc = max(auc, 1 - auc)
            null_gap = abs(x[y == 1].isna().mean() - x[y == 0].isna().mean())
            rows.append((col, auc, null_gap))
    out = pd.DataFrame(rows, columns=["feature", "auc", "null_gap"])
    return out[(out.auc > thresh) | (out.null_gap > 0.10)].sort_values("auc", ascending=False)
