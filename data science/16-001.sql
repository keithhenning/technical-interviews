CREATE OR REPLACE TABLE recon.orders_clean AS
SELECT
  order_id,
  amount_cents,
  LOWER(TRIM(customer_email)) AS email_norm,
  created_at,
  status
FROM raw.orders_cdc
WHERE DATE(created_at) = '2026-08-11'
QUALIFY ROW_NUMBER() OVER (
  PARTITION BY order_id
  ORDER BY updated_at DESC, ingest_ts DESC) = 1
  AND status IN ('paid', 'fulfilled', 'refunded');
