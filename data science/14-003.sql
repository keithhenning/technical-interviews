SELECT
  variant,
  CASE
    WHEN t4 IS NOT NULL THEN 'purchased'
    WHEN t3 IS NOT NULL THEN 'dropped_at_checkout'
    WHEN t2 IS NOT NULL THEN 'dropped_at_cart'
    ELSE 'dropped_at_view'
  END AS outcome,
  COUNT(*) AS users,
  SAFE_DIVIDE(COUNT(*), SUM(COUNT(*)) OVER (PARTITION BY variant)) AS share
FROM labelled
GROUP BY variant, outcome
ORDER BY variant, outcome;
