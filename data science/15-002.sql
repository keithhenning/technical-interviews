CREATE OR REPLACE TABLE analytics.sessions
PARTITION BY DATE(session_start) CLUSTER BY device_id AS
SELECT
  session_id, device_id,
  MIN(event_ts) AS session_start,
  MAX(event_ts) AS session_end,
  TIMESTAMP_DIFF(MAX(event_ts), MIN(event_ts), SECOND) AS duration_s,
  COUNT(*) AS pageviews,
  ARRAY_AGG(page ORDER BY event_ts LIMIT 1)[OFFSET(0)] AS entry_page,
  ARRAY_AGG(page ORDER BY event_ts DESC LIMIT 1)[OFFSET(0)] AS exit_page,
  COUNT(*) = 1 AS is_bounce
FROM analytics.sessionized_events
GROUP BY session_id, device_id;
