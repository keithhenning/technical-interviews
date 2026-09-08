from math import sqrt, ceil
from scipy.stats import norm

def n_per_arm(p1, rel_lift, alpha=0.05, power=0.80):
    p2 = p1 * (1 + rel_lift)
    pbar = (p1 + p2) / 2
    za = norm.ppf(1 - alpha / 2)
    zb = norm.ppf(power)
    num = (za * sqrt(2 * pbar * (1 - pbar))
           + zb * sqrt(p1 * (1 - p1) + p2 * (1 - p2))) ** 2
    return ceil(num / (p2 - p1) ** 2)

for lift in [0.01, 0.02, 0.03]:
    print(lift, n_per_arm(0.62, lift))
