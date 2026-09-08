user_days = (
    events.loc[events["event_name"].isin(ACTIVE), ["user_id", "activity_date"]]
    .drop_duplicates()
)
dau = user_days.groupby("activity_date")["user_id"].nunique()

first = user_days.groupby("user_id")["activity_date"].min().rename("first_date")
ud = user_days.join(first, on="user_id")
ud["day_n"] = (ud["activity_date"] - ud["first_date"]).dt.days
ud["cohort_week"] = ud["first_date"].dt.to_period("W-SUN").dt.start_time

cohort_size = ud.loc[ud["day_n"] == 0].groupby("cohort_week")["user_id"].nunique()
retained = (
    ud.loc[ud["day_n"].isin([1, 7, 30])]
    .groupby(["cohort_week", "day_n"])["user_id"].nunique()
    .unstack("day_n", fill_value=0)
)
retention = retained.div(cohort_size, axis=0)

age_days = (ud["activity_date"].max() - retention.index).days
for n in [1, 7, 30]:
    retention.loc[age_days < n + 6, n] = float("nan")
