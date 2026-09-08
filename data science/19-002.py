from sklearn.calibration import CalibratedClassifierCV
from sklearn.metrics import brier_score_loss

cal = CalibratedClassifierCV(base_model, method="isotonic", cv="prefit")
cal.fit(X_valid, y_valid)
p_test = cal.predict_proba(X_test)[:, 1]
print("brier", brier_score_loss(y_test, p_test))

ev = 0.25 * p_test * 72 - 10
targets = (ev > 0)
print("subscribers worth targeting", targets.sum())
