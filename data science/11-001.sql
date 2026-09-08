SELECT
  r.city,
  r.category,
  DATE_TRUNC('week', r.posted_at) AS wk,
  COUNT(*) AS requests,
  SUM(CASE WHEN a.accepted_at IS NOT NULL
            AND a.accepted_at <= r.posted_at + INTERVAL '48 hours'
           THEN 1 ELSE 0 END) AS filled_48h,
  SUM(CASE WHEN a.accepted_at IS NOT NULL
            AND a.accepted_at <= r.posted_at + INTERVAL '48 hours'
           THEN 1 ELSE 0 END) * 1.0 / COUNT(*) AS fill_rate_48h
FROM requests r
LEFT JOIN acceptances a ON a.request_id = r.request_id
WHERE r.posted_at >= CURRENT_DATE - INTERVAL '12 weeks'
GROUP BY 1, 2, 3
