import statsmodels.formula.api as smf
# df: market, week, log_bookings, treated (0/1), post (0/1)
df["did"] = df["treated"] * df["post"]
m = smf.ols("log_bookings ~ C(market) + C(week) + did", data=df).fit(
    cov_type="cluster", cov_kwds={"groups": df["market"]})
print(m.params["did"], m.conf_int().loc["did"])
