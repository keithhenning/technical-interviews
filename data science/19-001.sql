WITH scoring_dates AS (
  SELECT DATE_TRUNC('month', d) AS score_date
  FROM UNNEST(GENERATE_DATE_ARRAY('2025-01-01', '2026-06-01', INTERVAL 1 MONTH)) AS d
),
active AS (
  SELECT s.sub_id, sd.score_date
  FROM subscriptions s
  JOIN scoring_dates sd
    ON s.started_at < sd.score_date
   AND (s.ended_at IS NULL OR s.ended_at >= sd.score_date)
),
labels AS (
  SELECT a.sub_id, a.score_date,
         CASE WHEN s.ended_at IS NOT NULL
               AND s.ended_at < a.score_date + INTERVAL '30 days'
              THEN 1 ELSE 0 END AS churned
  FROM active a JOIN subscriptions s USING (sub_id)
)
SELECT * FROM labels;
