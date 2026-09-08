import pandas as pd

def lead_score(panel: pd.DataFrame, candidate: str, lag_weeks: int = 4) -> float:
    # panel has columns: cell, wk, completed_jobs, and the candidate metric
    df = panel.sort_values(["cell", "wk"]).copy()
    df["future_jobs"] = df.groupby("cell")["completed_jobs"].shift(-lag_weeks)
    df = df.dropna(subset=["future_jobs", candidate])
    # within-cell correlation so city size doesn't dominate
    return (
        df.groupby("cell")
          .apply(lambda g: g[candidate].corr(g["future_jobs"]))
          .median()
    )
