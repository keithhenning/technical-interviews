WITH bureau_asof AS (
  SELECT l.loan_id, b.utilization, b.inquiries_6m,
         ROW_NUMBER() OVER (PARTITION BY l.loan_id
                            ORDER BY b.pulled_at DESC) AS rn
  FROM loans l
  JOIN bureau_snapshots b
    ON b.customer_id = l.customer_id
   AND b.pulled_at <= l.decision_ts
)
SELECT loan_id, utilization, inquiries_6m
FROM bureau_asof WHERE rn = 1
