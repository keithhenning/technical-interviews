WITH first_seen AS (
  SELECT user_id, MIN(activity_date) AS first_date
  FROM analytics.user_days
  GROUP BY user_id
),
joined AS (
  SELECT
    DATE_TRUNC(f.first_date, WEEK(MONDAY)) AS cohort_week,
    u.user_id,
    DATE_DIFF(u.activity_date, f.first_date, DAY) AS day_n
  FROM first_seen f
  JOIN analytics.user_days u USING (user_id)
)
SELECT
  cohort_week,
  COUNT(DISTINCT IF(day_n = 0, user_id, NULL))  AS cohort_size,
  SAFE_DIVIDE(COUNT(DISTINCT IF(day_n = 1,  user_id, NULL)),
              COUNT(DISTINCT IF(day_n = 0,  user_id, NULL))) AS d1,
  SAFE_DIVIDE(COUNT(DISTINCT IF(day_n = 7,  user_id, NULL)),
              COUNT(DISTINCT IF(day_n = 0,  user_id, NULL))) AS d7,
  SAFE_DIVIDE(COUNT(DISTINCT IF(day_n = 30, user_id, NULL)),
              COUNT(DISTINCT IF(day_n = 0,  user_id, NULL))) AS d30
FROM joined
GROUP BY cohort_week
ORDER BY cohort_week;
