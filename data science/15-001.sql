WITH ordered AS (
  SELECT
    device_id, event_ts, page,
    LAG(event_ts) OVER (PARTITION BY device_id ORDER BY event_ts) AS prev_ts
  FROM raw.events
  WHERE DATE(event_ts) = '2026-08-10'
),
flagged AS (
  SELECT *,
    IF(prev_ts IS NULL
       OR TIMESTAMP_DIFF(event_ts, prev_ts, SECOND) > 1800, 1, 0) AS is_new
  FROM ordered
),
numbered AS (
  SELECT *,
    SUM(is_new) OVER (
      PARTITION BY device_id ORDER BY event_ts
      ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS session_seq
  FROM flagged
)
SELECT
  CONCAT(device_id, '-20260810-', CAST(session_seq AS STRING)) AS session_id,
  device_id, event_ts, page, DATE(event_ts) AS activity_date
FROM numbered;
