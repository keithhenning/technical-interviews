SELECT
  DATE_TRUNC('week', first_exposure) AS wk,
  SUM(CASE WHEN variant = 'control' THEN 1 ELSE 0 END) AS n_control,
  SUM(CASE WHEN variant = 'treatment' THEN 1 ELSE 0 END) AS n_treat
FROM (
  SELECT user_id, variant, MIN(exposed_at) AS first_exposure
  FROM exposures
  WHERE experiment = 'rec_module_v1'
  GROUP BY 1, 2
) e
GROUP BY 1
ORDER BY 1;
