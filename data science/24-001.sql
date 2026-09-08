WITH scored AS (
  SELECT
    CASE
      WHEN ad_age_hours < 24 THEN 'new'
      WHEN ad_age_hours < 168 THEN 'week'
      ELSE 'mature' END AS ad_age_bucket,
    NTILE(20) OVER (ORDER BY pctr_at_serve) AS pctr_bin,
    pctr_at_serve,
    clicked
  FROM impressions
  WHERE shown_at >= CURRENT_TIMESTAMP - INTERVAL 1 HOUR
)
SELECT
  ad_age_bucket,
  pctr_bin,
  AVG(pctr_at_serve) AS predicted,
  AVG(clicked) AS observed,
  SAFE_DIVIDE(AVG(pctr_at_serve), AVG(clicked)) AS calibration_ratio,
  COUNT(*) AS n
FROM scored
GROUP BY 1, 2
ORDER BY 1, 2
