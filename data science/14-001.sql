WITH base AS (
  SELECT user_id, event_name, event_ts
  FROM raw.events
  WHERE DATE(event_ts) BETWEEN '2026-08-03' AND '2026-08-16'
    AND event_name IN ('view_product','add_to_cart','checkout_start','purchase')
),
s1 AS (
  SELECT user_id, MIN(event_ts) AS t1,
         TIMESTAMP_ADD(MIN(event_ts), INTERVAL 7 DAY) AS deadline
  FROM base WHERE event_name = 'view_product'
    AND DATE(event_ts) BETWEEN '2026-08-03' AND '2026-08-09'
  GROUP BY user_id
),
s2 AS (
  SELECT b.user_id, MIN(b.event_ts) AS t2, ANY_VALUE(s1.deadline) AS deadline
  FROM base b JOIN s1 USING (user_id)
  WHERE b.event_name = 'add_to_cart' AND b.event_ts > s1.t1 AND b.event_ts <= s1.deadline
  GROUP BY b.user_id
),
s3 AS (
  SELECT b.user_id, MIN(b.event_ts) AS t3, ANY_VALUE(s2.deadline) AS deadline
  FROM base b JOIN s2 USING (user_id)
  WHERE b.event_name = 'checkout_start' AND b.event_ts > s2.t2 AND b.event_ts <= s2.deadline
  GROUP BY b.user_id
),
s4 AS (
  SELECT b.user_id, MIN(b.event_ts) AS t4
  FROM base b JOIN s3 USING (user_id)
  WHERE b.event_name = 'purchase' AND b.event_ts > s3.t3 AND b.event_ts <= s3.deadline
  GROUP BY b.user_id
)
SELECT s1.user_id, s1.t1, s2.t2, s3.t3, s4.t4
FROM s1
LEFT JOIN s2 USING (user_id)
LEFT JOIN s3 USING (user_id)
LEFT JOIN s4 USING (user_id);
