def first_step(name):
    s = (events.loc[events["event_name"] == name]
         .groupby("user_id", as_index=False)["event_ts"].min())
    return s.rename(columns={"event_ts": "t1"}).assign(
        deadline=lambda d: d["t1"] + pd.Timedelta(days=7))

def next_step(prev, prev_col, name, col):
    e = (events.loc[events["event_name"] == name, ["user_id", "event_ts"]]
         .merge(prev[["user_id", prev_col, "deadline"]], on="user_id"))
    e = e[(e["event_ts"] > e[prev_col]) & (e["event_ts"] <= e["deadline"])]
    best = e.groupby("user_id", as_index=False).agg(**{col: ("event_ts", "min")})
    return prev.merge(best, on="user_id", how="left")

funnel = first_step("view_product")
funnel = next_step(funnel, "t1", "add_to_cart", "t2")
funnel = next_step(funnel, "t2", "checkout_start", "t3")
funnel = next_step(funnel, "t3", "purchase", "t4")

reached = funnel[["t1", "t2", "t3", "t4"]].notna().sum()
report = pd.DataFrame({"users": reached,
                       "step_conv": reached / reached.shift(1),
                       "cum_conv": reached / reached.iloc[0]})
median_minutes = (funnel["t4"] - funnel["t1"]).dt.total_seconds().div(60).median()
