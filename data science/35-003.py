def di_ratio(df, group_col, decision_col, n_boot=1000, seed=0):
    rng = np.random.default_rng(seed)
    rates = df.groupby(group_col)[decision_col].mean()
    ref = rates.idxmax()
    out = {}
    for g in rates.index:
        boots = []
        for _ in range(n_boot):
            s = df.sample(frac=1.0, replace=True, random_state=rng.integers(1e9))
            r = s.groupby(group_col)[decision_col].mean()
            boots.append(r[g] / r[ref])
        out[g] = (rates[g] / rates[ref], np.percentile(boots, [2.5, 97.5]))
    return out
