from rdrobust import rdrobust, rddensity
d = pros[pros.market.isin(treated_markets)]
d["running"] = d["jobs_at_launch"] - 10
print(rddensity(d["running"]))  # manipulation test at the cutoff
out = rdrobust(y=d["post_log_bookings"], x=d["running"], c=0, fuzzy=d["got_badge"])
print(out)
