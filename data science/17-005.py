orders = (orders_raw.sort_values(["order_id", "updated_at", "ingest_ts"])
          .drop_duplicates("order_id", keep="last"))
orders = orders[orders["status"].isin(["paid", "fulfilled"])].copy()
orders["amount_cents"] = (orders["amount"] * 100).round().astype("int64")
orders["email_norm"] = orders["customer_email"].str.strip().str.lower()

settle = pd.read_csv("settlements.csv", dtype="string")
settle["amount_cents"] = (settle["amount_text"].str.replace(",", "", regex=False)
                          .astype(float).mul(100).round().astype("int64"))
settle["reference_norm"] = (settle["reference"].str.strip().str.upper()
                            .str.replace(r"^PAY-", "", regex=True))
settle["email_norm"] = settle["payer_email"].str.strip().str.lower()
settle["settled_at"] = pd.to_datetime(settle["settled_at"], utc=True)

exact = orders.merge(settle, left_on="order_id", right_on="reference_norm",
                     how="outer", indicator=True, validate="one_to_one")
print(exact["_merge"].value_counts())

rest_o = orders.loc[~orders["order_id"].isin(settle["reference_norm"])].sort_values("created_at")
rest_s = settle.loc[~settle["reference_norm"].isin(orders["order_id"])].sort_values("settled_at")
fuzzy = pd.merge_asof(rest_o, rest_s, left_on="created_at", right_on="settled_at",
                      by=["amount_cents", "email_norm"], direction="forward",
                      tolerance=pd.Timedelta(hours=72))
