WITH ranked AS (
  SELECT
    o.order_id,
    f.avg_prep_time_30d,
    f.orders_last_7d,
    ROW_NUMBER() OVER (
      PARTITION BY o.order_id
      ORDER BY f.available_time DESC
    ) AS rn
  FROM orders o
  JOIN restaurant_features_daily f
    ON f.restaurant_id = o.restaurant_id
   AND f.available_time <= o.placed_at
   AND f.available_time >  o.placed_at - INTERVAL '3 days'
)
SELECT order_id, avg_prep_time_30d, orders_last_7d
FROM ranked
WHERE rn = 1
