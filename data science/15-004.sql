WITH gaps AS (
  SELECT TIMESTAMP_DIFF(event_ts,
           LAG(event_ts) OVER (PARTITION BY device_id ORDER BY event_ts), SECOND) AS gap_s
  FROM raw.events
  WHERE DATE(event_ts) BETWEEN '2026-08-01' AND '2026-08-07'
)
SELECT
  CAST(FLOOR(LOG(gap_s + 1, 2)) AS INT64) AS log2_bucket,
  POW(2, CAST(FLOOR(LOG(gap_s + 1, 2)) AS INT64)) AS bucket_floor_s,
  COUNT(*) AS n
FROM gaps
WHERE gap_s IS NOT NULL AND gap_s >= 0
GROUP BY log2_bucket
ORDER BY log2_bucket;
