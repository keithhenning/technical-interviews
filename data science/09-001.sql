WITH exposed AS (
  SELECT user_id, variant_id, MIN(exposed_at) AS exposed_at
  FROM exposures
  WHERE experiment_id = 'short_video_v1'
  GROUP BY 1, 2
),
engaged AS (
  SELECT
    e.user_id,
    e.variant_id,
    DATE_TRUNC('week', ev.event_ts) AS wk,
    1 AS engaged
  FROM exposed e
  JOIN events ev ON ev.user_id = e.user_id
  WHERE ev.event_ts >= e.exposed_at
    AND (ev.event_type IN ('like','comment','share')
         OR (ev.event_type = 'view_progress' AND ev.watch_seconds >= 10))
  GROUP BY 1, 2, 3
)
SELECT variant_id, wk, COUNT(DISTINCT user_id) AS engaged_users
FROM engaged
GROUP BY 1, 2
ORDER BY 2, 1
