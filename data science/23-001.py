import statsmodels.formula.api as smf

# quotes: one row per quote in perturbed zone-buckets
# log_mult_policy is what the policy chose; log_mult_shown includes the jitter
# jitter = log_mult_shown - log_mult_policy is random by construction
quotes["jitter"] = quotes["log_mult_shown"] - quotes["log_mult_policy"]
model = smf.logit(
    "requested ~ jitter + C(zone_id) * C(hour_bucket) + log_mult_policy",
    data=quotes,
).fit()
# elasticity at the mean conversion rate p:
p = quotes["requested"].mean()
elasticity = model.params["jitter"] * (1 - p)
