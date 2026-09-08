from sklearn.calibration import calibration_curve, CalibratedClassifierCV
from sklearn.metrics import brier_score_loss, log_loss

prob_true, prob_pred = calibration_curve(y_cal, raw_scores, n_bins=10,
                                         strategy="quantile")
ece = np.abs(prob_true - prob_pred).mean()
print("ECE", round(ece, 4), "Brier", round(brier_score_loss(y_cal, raw_scores), 4))

calibrated = CalibratedClassifierCV(base_model, method="isotonic", cv="prefit")
calibrated.fit(X_cal, y_cal)
print("log loss after", round(log_loss(y_test, calibrated.predict_proba(X_test)[:, 1]), 4))
