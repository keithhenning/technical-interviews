WITH m AS (SELECT * FROM recon.matches),
joined AS (
  SELECT
    o.order_id, s.settlement_id, m.match_tier,
    o.amount_cents AS order_cents, s.amount_cents AS settle_cents
  FROM recon.orders_clean o
  FULL OUTER JOIN m ON m.order_id = o.order_id
  FULL OUTER JOIN recon.settlements_clean s ON s.settlement_id = m.settlement_id
)
SELECT
  CASE
    WHEN order_id IS NULL THEN 'settlement_only'
    WHEN settlement_id IS NULL THEN 'order_only'
    WHEN order_cents <> settle_cents THEN 'amount_mismatch'
    ELSE 'matched'
  END AS status,
  COUNT(*) AS rows_n,
  SUM(COALESCE(order_cents, 0)) / 100 AS order_dollars,
  SUM(COALESCE(settle_cents, 0)) / 100 AS settle_dollars,
  SUM(COALESCE(settle_cents, 0) - COALESCE(order_cents, 0)) / 100 AS diff_dollars
FROM joined
GROUP BY status
ORDER BY status;
