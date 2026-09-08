SELECT
  CASE WHEN s.segment IN ('new_vs_returning', 'device') THEN 'preregistered'
       ELSE 'exploratory' END AS segment_class,
  s.segment, s.segment_value, s.variant,
  COUNT(*) AS users,
  AVG(c.converted) AS conv_rate
FROM user_segments s
JOIN user_conversions c USING (user_id)
WHERE c.experiment = 'checkout_v2'
GROUP BY 1, 2, 3, 4
ORDER BY 1, 2, 3, 4;
