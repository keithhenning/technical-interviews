ev = events.sort_values(["user_id", "event_ts"], kind="stable").copy()
gap = ev.groupby("user_id", observed=True)["event_ts"].diff()
ev["is_new"] = (gap.isna() | (gap > pd.Timedelta(minutes=30))).astype("int8")
ev["session_seq"] = ev.groupby("user_id", observed=True)["is_new"].cumsum()
ev["session_id"] = ev["user_id"] + "-" + ev["session_seq"].astype("string")

sessions = ev.groupby("session_id", observed=True).agg(
    user_id=("user_id", "first"),
    start=("event_ts", "min"),
    end=("event_ts", "max"),
    pageviews=("page", "size"),
    entry_page=("page", "first"),
    exit_page=("page", "last"),
)
sessions["duration_s"] = (sessions["end"] - sessions["start"]).dt.total_seconds()
sessions["is_bounce"] = sessions["pageviews"] == 1
