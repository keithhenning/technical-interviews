WITH first_exposure AS (
  SELECT unit_id, variant_id, MIN(exposed_at) AS exposed_at
  FROM exposures
  WHERE experiment_id = 'exp_2041'
  GROUP BY unit_id, variant_id
)
SELECT
  e.unit_id,
  e.variant_id,
  COALESCE(SUM(o.order_value), 0) AS revenue,
  MAX(CASE WHEN o.order_id IS NOT NULL THEN 1 ELSE 0 END) AS converted
FROM first_exposure e
LEFT JOIN orders o
  ON o.user_id = e.unit_id
 AND o.created_at >= e.exposed_at
 AND o.created_at < TIMESTAMP '2026-09-05'
GROUP BY 1, 2
