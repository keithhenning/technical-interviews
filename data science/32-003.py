from sklearn.model_selection import KFold

def oof_target_encode(cat, y, n_splits=5, alpha=20):
    enc = np.zeros(len(cat))
    prior = y.mean()
    for tr, va in KFold(n_splits, shuffle=True, random_state=0).split(cat):
        stats = pd.DataFrame({"c": cat.iloc[tr], "y": y.iloc[tr]}).groupby("c")["y"].agg(["sum", "count"])
        smoothed = (stats["sum"] + alpha * prior) / (stats["count"] + alpha)
        enc[va] = cat.iloc[va].map(smoothed).fillna(prior).values
    return enc
