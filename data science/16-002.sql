WITH exact AS (
  SELECT o.order_id, s.settlement_id, 'exact_ref' AS match_tier
  FROM recon.orders_clean o
  JOIN recon.settlements_clean s ON s.reference_norm = o.order_id
),
rest_o AS (
  SELECT * FROM recon.orders_clean
  WHERE order_id NOT IN (SELECT order_id FROM exact)
),
rest_s AS (
  SELECT * FROM recon.settlements_clean
  WHERE settlement_id NOT IN (SELECT settlement_id FROM exact)
),
candidates AS (
  SELECT o.order_id, s.settlement_id,
         ABS(TIMESTAMP_DIFF(s.settled_at, o.created_at, MINUTE)) AS gap_min
  FROM rest_o o
  JOIN rest_s s
    ON s.amount_cents = o.amount_cents
   AND s.email_norm = o.email_norm
   AND s.settled_at BETWEEN o.created_at
                        AND TIMESTAMP_ADD(o.created_at, INTERVAL 72 HOUR)
),
best_per_order AS (
  SELECT * FROM candidates
  QUALIFY ROW_NUMBER() OVER (PARTITION BY order_id ORDER BY gap_min, settlement_id) = 1
),
fuzzy AS (
  SELECT order_id, settlement_id, 'amount_email_72h' AS match_tier
  FROM best_per_order
  QUALIFY ROW_NUMBER() OVER (PARTITION BY settlement_id ORDER BY gap_min, order_id) = 1
)
SELECT * FROM exact UNION ALL SELECT * FROM fuzzy;
