WITH labelled AS (
  SELECT f.*, x.variant
  FROM analytics.user_funnel f
  JOIN raw.exposures x
    ON x.user_id = f.user_id
   AND x.experiment_id = 'checkout_redesign_v2'
   AND x.exposed_at <= f.t1
),
long AS (
  SELECT variant, 1 AS step, COUNT(*) AS users FROM labelled GROUP BY variant
  UNION ALL
  SELECT variant, 2, COUNTIF(t2 IS NOT NULL) FROM labelled GROUP BY variant
  UNION ALL
  SELECT variant, 3, COUNTIF(t3 IS NOT NULL) FROM labelled GROUP BY variant
  UNION ALL
  SELECT variant, 4, COUNTIF(t4 IS NOT NULL) FROM labelled GROUP BY variant
)
SELECT
  variant, step, users,
  SAFE_DIVIDE(users, LAG(users) OVER (PARTITION BY variant ORDER BY step)) AS step_conv,
  SAFE_DIVIDE(users, FIRST_VALUE(users) OVER (PARTITION BY variant ORDER BY step)) AS cum_conv
FROM long
ORDER BY variant, step;
