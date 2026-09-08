def qini_curve(uplift_pred, y, w, n_bins=20):
    order = np.argsort(-uplift_pred)
    y, w = y[order], w[order]
    n = len(y)
    pts = [(0.0, 0.0)]
    for k in range(1, n_bins + 1):
        i = int(n * k / n_bins)
        yt, yc = y[:i][w[:i] == 1], y[:i][w[:i] == 0]
        nt, nc = max(len(yt), 1), max(len(yc), 1)
        # incremental orders scaled to treated count
        inc = yt.sum() - yc.sum() * nt / nc
        pts.append((i / n, inc))
    return pts
