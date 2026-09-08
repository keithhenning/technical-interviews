WITH orders_12m AS (
  SELECT customer_id, order_date, revenue, discount_amount, category_id
  FROM orders
  WHERE order_date >= DATE_SUB(@as_of, INTERVAL 12 MONTH)
    AND order_date < @as_of
)
SELECT
  customer_id,
  DATE_DIFF(@as_of, MAX(order_date), DAY) AS recency_days,
  COUNT(*) AS frequency,
  SUM(revenue) AS monetary,
  SAFE_DIVIDE(SUM(discount_amount), SUM(revenue + discount_amount)) AS discount_share,
  COUNT(DISTINCT category_id) AS category_breadth,
  SAFE_DIVIDE(DATE_DIFF(MAX(order_date), MIN(order_date), DAY),
              NULLIF(COUNT(*) - 1, 0)) AS avg_days_between
FROM orders_12m
GROUP BY customer_id
