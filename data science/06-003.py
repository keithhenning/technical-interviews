import numpy as np
def cuped(y, x):
    theta = np.cov(x, y, ddof=1)[0, 1] / np.var(x, ddof=1)
    return y - theta * (x - x.mean())

for arm in ("control", "treatment"):
    m = df[df.variant == arm]
    df.loc[m.index, "y_adj"] = cuped(m["orders"].values,
                                     m["pre_orders"].values)
ctrl = df[df.variant == "control"]["y_adj"]
trt = df[df.variant == "treatment"]["y_adj"]
diff = trt.mean() - ctrl.mean()
se = np.sqrt(trt.var(ddof=1) / len(trt) + ctrl.var(ddof=1) / len(ctrl))
print(f"lift={diff/ctrl.mean():.4f} ci=({(diff-1.96*se)/ctrl.mean():.4f}, "
      f"{(diff+1.96*se)/ctrl.mean():.4f})")
