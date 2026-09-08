import pandas as pd

def decompose(before: pd.DataFrame, after: pd.DataFrame, dim: str) -> pd.DataFrame:
    b = before.groupby(dim).agg(s=("sessions", "sum"), o=("orders", "sum"))
    a = after.groupby(dim).agg(s=("sessions", "sum"), o=("orders", "sum"))
    df = b.join(a, lsuffix="_b", rsuffix="_a").fillna(0)
    df["share_b"] = df.s_b / df.s_b.sum()
    df["share_a"] = df.s_a / df.s_a.sum()
    df["cvr_b"] = df.o_b / df.s_b
    df["cvr_a"] = df.o_a / df.s_a
    df["rate_effect"] = df.share_b * (df.cvr_a - df.cvr_b)
    df["mix_effect"] = (df.share_a - df.share_b) * df.cvr_b
    df["total_effect"] = df.rate_effect + df.mix_effect
    return df.sort_values("total_effect")
