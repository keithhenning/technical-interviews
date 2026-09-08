import numpy as np
from sklearn.ensemble import GradientBoostingClassifier
from sklearn.utils import resample

preds = []
for seed in range(30):
    Xb, yb = resample(X_train, y_train, random_state=seed)
    m = GradientBoostingClassifier(max_depth=6, n_estimators=400)
    m.fit(Xb, yb)
    preds.append(m.predict_proba(X_test)[:, 1])
preds = np.array(preds)                # shape (30, n_test)
variance = preds.var(axis=0).mean()     # avg per-point spread
mean_pred = preds.mean(axis=0)          # compare to labels for bias
