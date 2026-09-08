# per-user share of a user's total: transform broadcasts the group value
orders["user_total"] = orders.groupby("user_id", observed=True)["amount_cents"].transform("sum")
orders["share"] = orders["amount_cents"] / orders["user_total"]

# lookup from a small table: map, not a Python dict loop
country = users.set_index("user_id")["country"]
orders["country"] = orders["user_id"].map(country)

# conditional column: numpy select, not apply
import numpy as np
orders["bucket"] = np.select(
    [orders["amount_cents"] < 1000, orders["amount_cents"] < 10000],
    ["small", "medium"], default="large")
