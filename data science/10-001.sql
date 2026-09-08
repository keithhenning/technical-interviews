SELECT
  DATE_TRUNC('hour', s.started_at) AS hr,
  COUNT(DISTINCT s.session_id) AS sessions,
  COUNT(DISTINCT o.order_id) AS orders,
  COUNT(DISTINCT o.order_id) * 1.0 / COUNT(DISTINCT s.session_id) AS cvr
FROM sessions s
LEFT JOIN orders o
  ON o.session_id = s.session_id
WHERE s.started_at >= CURRENT_DATE - INTERVAL '7 days'
GROUP BY 1
ORDER BY 1
