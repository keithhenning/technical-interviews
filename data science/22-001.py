def add_lag_features(df, origin_col="origin_date"):
    # df: one row per (store, sku, date, units); sorted by date
    g = df.groupby(["store_id", "sku_id"])["units"]
    for lag in (7, 14, 28, 364):
        df[f"lag_{lag}"] = g.shift(lag)
    for win in (7, 28, 91):
        df[f"roll_mean_{win}"] = (
            g.shift(1).rolling(win, min_periods=1).mean()
            .reset_index(level=[0, 1], drop=True)
        )
    # every feature above uses only data at or before date - 1,
    # so it is safe for any origin >= date
    return df
