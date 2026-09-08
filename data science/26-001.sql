WITH hist AS (
  SELECT metric, slice, ts, value,
         AVG(value) OVER (
           PARTITION BY metric, slice, EXTRACT(HOUR FROM ts), EXTRACT(DAYOFWEEK FROM ts)
           ORDER BY ts ROWS BETWEEN 8 PRECEDING AND 1 PRECEDING) AS mu,
         STDDEV(value) OVER (
           PARTITION BY metric, slice, EXTRACT(HOUR FROM ts), EXTRACT(DAYOFWEEK FROM ts)
           ORDER BY ts ROWS BETWEEN 8 PRECEDING AND 1 PRECEDING) AS sigma
  FROM hourly_metrics
)
SELECT metric, slice, ts, value, mu, sigma,
       SAFE_DIVIDE(value - mu, sigma) AS z
FROM hist
WHERE ts = TIMESTAMP_TRUNC(CURRENT_TIMESTAMP(), HOUR)
  AND ABS(SAFE_DIVIDE(value - mu, sigma)) > 3
