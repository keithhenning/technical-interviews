from sklearn.isotonic import IsotonicRegression
from sklearn.calibration import calibration_curve

iso = IsotonicRegression(out_of_bounds="clip")
iso.fit(raw_val_scores, y_val)          # y_val at true 0.8% prevalence
cal_test = iso.predict(raw_test_scores)
pt, pp = calibration_curve(y_test, cal_test, n_bins=10, strategy="quantile")
print("ECE", round(np.abs(pt - pp).mean(), 4))
