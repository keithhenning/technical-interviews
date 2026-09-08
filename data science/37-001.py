import numpy as np

def psi(reference, current, bins=10, eps=1e-6):
    edges = np.quantile(reference, np.linspace(0, 1, bins + 1))
    edges[0], edges[-1] = -np.inf, np.inf
    ref_pct = np.histogram(reference, edges)[0] / len(reference) + eps
    cur_pct = np.histogram(current, edges)[0] / len(current) + eps
    return float(np.sum((cur_pct - ref_pct) * np.log(cur_pct / ref_pct)))

# Rule of thumb: under 0.1 stable, 0.1 to 0.2 investigate, over 0.2 alert
