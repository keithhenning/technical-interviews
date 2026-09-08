WITH first_order AS (
  SELECT customer_id, channel,
         MIN(order_date) AS acquired_on
  FROM orders GROUP BY customer_id, channel
),
value_24m AS (
  SELECT f.customer_id, f.channel,
         DATE_TRUNC(f.acquired_on, MONTH) AS cohort,
         SUM(o.contribution_margin) AS cm_24m
  FROM first_order f
  JOIN orders o ON o.customer_id = f.customer_id
   AND o.order_date < DATE_ADD(f.acquired_on, INTERVAL 24 MONTH)
  WHERE f.acquired_on < DATE_SUB(CURRENT_DATE(), INTERVAL 24 MONTH)
  GROUP BY 1, 2, 3
)
SELECT channel, cohort, COUNT(*) AS customers,
       AVG(cm_24m) AS avg_clv_24m,
       STDDEV(cm_24m) / SQRT(COUNT(*)) AS se
FROM value_24m
GROUP BY 1, 2 ORDER BY 1, 2
