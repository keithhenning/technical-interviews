WITH exposed AS (
  SELECT user_id, variant, MIN(exposed_at) AS first_exposure
  FROM exposures
  WHERE experiment = 'checkout_v2'
  GROUP BY user_id, variant
),
converted AS (
  SELECT e.user_id, e.variant,
         MAX(CASE WHEN o.order_id IS NOT NULL THEN 1 ELSE 0 END) AS converted
  FROM exposed e
  LEFT JOIN orders o
    ON o.user_id = e.user_id
   AND o.created_at >= e.first_exposure
   AND o.created_at < e.first_exposure + INTERVAL '7 days'
  GROUP BY e.user_id, e.variant
)
SELECT variant, COUNT(*) AS users, AVG(converted) AS conv_rate
FROM converted
GROUP BY variant;
