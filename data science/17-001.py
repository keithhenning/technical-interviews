import pandas as pd

ACTIVE = ["view_product", "add_to_cart", "checkout_start", "purchase", "deposit"]

events = pd.read_csv(
    "events.csv",
    dtype={"user_id": "string", "event_name": "category",
           "platform": "category", "page": "string"},
    parse_dates=["event_ts"],
)
events["event_ts"] = events["event_ts"].dt.tz_localize("UTC")
events["activity_date"] = events["event_ts"].dt.tz_convert(None).dt.normalize()

orders_raw = pd.read_csv(
    "orders.csv",
    dtype={"order_id": "string", "user_id": "string", "status": "category",
           "customer_email": "string"},
    parse_dates=["created_at", "updated_at", "ingest_ts"],
)
for c in ["created_at", "updated_at", "ingest_ts"]:
    orders_raw[c] = orders_raw[c].dt.tz_localize("UTC")
print(events.shape, events.memory_usage(deep=True).sum() / 1e9, "GB")
