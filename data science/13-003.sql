WITH spine AS (
  SELECT d
  FROM UNNEST(GENERATE_DATE_ARRAY('2026-06-01', '2026-08-31')) AS d
)
SELECT
  s.d AS activity_date,
  COUNT(DISTINCT IF(u.activity_date = s.d, u.user_id, NULL)) AS dau,
  COUNT(DISTINCT IF(u.activity_date > DATE_SUB(s.d, INTERVAL 7 DAY),
                    u.user_id, NULL)) AS wau,
  COUNT(DISTINCT u.user_id) AS mau,
  SAFE_DIVIDE(
    COUNT(DISTINCT IF(u.activity_date = s.d, u.user_id, NULL)),
    COUNT(DISTINCT u.user_id)) AS stickiness
FROM spine s
LEFT JOIN analytics.user_days u
  ON u.activity_date BETWEEN DATE_SUB(s.d, INTERVAL 29 DAY) AND s.d
GROUP BY s.d
ORDER BY s.d;
