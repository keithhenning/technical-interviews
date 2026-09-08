from scipy.stats import chisquare
observed = [28_112, 27_888]
expected = [sum(observed) / 2] * 2
stat, p = chisquare(observed, expected)
print(f"SRM chi2={stat:.2f} p={p:.3f}")
