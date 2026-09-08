from lifetimes import BetaGeoFitter, GammaGammaFitter
from lifetimes.utils import summary_data_from_transaction_data

rfm = summary_data_from_transaction_data(
    orders, "customer_id", "order_date",
    monetary_value_col="contribution_margin",
    observation_period_end=cutoff_date)

bgf = BetaGeoFitter(penalizer_coef=0.01)
bgf.fit(rfm["frequency"], rfm["recency"], rfm["T"])

repeaters = rfm[rfm["frequency"] > 0]
ggf = GammaGammaFitter(penalizer_coef=0.01)
ggf.fit(repeaters["frequency"], repeaters["monetary_value"])

rfm["clv_24m"] = ggf.customer_lifetime_value(
    bgf, rfm["frequency"], rfm["recency"], rfm["T"],
    rfm["monetary_value"].clip(lower=0.01),
    time=24, freq="D", discount_rate=0.01)   # monthly discount
