import numpy as np
from scipy import stats

def score_point(y, yhat, resid_hist, kind):
    if kind == "count" and yhat < 30:
        # small counts: negative binomial tail probability
        r, p = 10.0, 10.0 / (10.0 + yhat)
        cdf = stats.nbinom.cdf(y, r, p)
        return min(cdf, 1 - cdf) * 2, None       # two sided p-value
    lo, hi = np.quantile(resid_hist, [0.001, 0.999])
    resid = y - yhat
    scale = np.median(np.abs(resid_hist - np.median(resid_hist))) * 1.4826
    return None, (resid < lo or resid > hi, resid / scale)
