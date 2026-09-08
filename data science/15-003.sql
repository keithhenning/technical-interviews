WITH seed AS (
  SELECT device_id, event_ts, page, session_id AS prior_id
  FROM analytics.sessionized_events
  WHERE activity_date = '2026-08-09'
  QUALIFY ROW_NUMBER() OVER (PARTITION BY device_id ORDER BY event_ts DESC) = 1
),
today AS (
  SELECT device_id, event_ts, page, CAST(NULL AS STRING) AS prior_id
  FROM raw.events WHERE DATE(event_ts) = '2026-08-10'
),
u AS (SELECT * FROM seed UNION ALL SELECT * FROM today),
flagged AS (
  SELECT *,
    IF(LAG(event_ts) OVER w IS NULL
       OR TIMESTAMP_DIFF(event_ts, LAG(event_ts) OVER w, SECOND) > 1800, 1, 0) AS is_new
  FROM u WINDOW w AS (PARTITION BY device_id ORDER BY event_ts)
),
numbered AS (
  SELECT *,
    SUM(is_new) OVER (PARTITION BY device_id ORDER BY event_ts
                      ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS seq,
    FIRST_VALUE(prior_id) OVER (PARTITION BY device_id ORDER BY event_ts) AS seed_id
  FROM flagged
)
SELECT device_id, event_ts, page, DATE(event_ts) AS activity_date,
  IF(seq = 1 AND seed_id IS NOT NULL, seed_id,
     CONCAT(device_id, '-20260810-', CAST(seq AS STRING))) AS session_id
FROM numbered
WHERE prior_id IS NULL;
