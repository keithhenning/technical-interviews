import pandas as pd
df = pd.read_parquet("exposed_users_weekly_orders.parquet")
# columns: user_id, variant, cohort_week, exposure_week, orders
df["weeks_since"] = df["exposure_week"] - df["cohort_week"]
g = (df.groupby(["cohort_week", "weeks_since", "variant"])["orders"]
       .mean().unstack("variant"))
g["lift_pct"] = 100 * (g["treatment"] / g["control"] - 1)
print(g["lift_pct"].unstack("weeks_since").round(2))
