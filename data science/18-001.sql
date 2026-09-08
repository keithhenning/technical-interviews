SELECT t.txn_id,
       t.created_at,
       t.amount,
       t.merchant_id,
       t.card_id,
       CASE WHEN c.txn_id IS NOT NULL
             AND c.reason_code IN ('fraud', 'unauthorized')
            THEN 1 ELSE 0 END AS is_fraud
FROM transactions t
LEFT JOIN chargebacks c ON c.txn_id = t.txn_id
WHERE t.created_at < CURRENT_DATE - INTERVAL '90 days'
  AND t.decision = 'approved';
