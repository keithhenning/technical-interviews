SELECT
  activity_date,
  COUNT(DISTINCT user_id) AS dau
FROM analytics.user_days
WHERE activity_date BETWEEN '2026-06-01' AND '2026-08-31'
GROUP BY activity_date
ORDER BY activity_date;
