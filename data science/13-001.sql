CREATE OR REPLACE TABLE analytics.user_days
PARTITION BY activity_date AS
SELECT
  user_id,
  DATE(event_ts) AS activity_date,
  COUNT(*) AS event_count
FROM raw.events
WHERE event_name IN ('lesson_started', 'lesson_completed', 'streak_checkin')
  AND user_id IS NOT NULL
GROUP BY user_id, activity_date;
