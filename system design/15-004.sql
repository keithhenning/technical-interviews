CREATE TABLE orders (
    order_id
                  SERIAL PRIMARY KEY,
    customer_id
                  INT,
    order_date
                  DATE,
    amount
                  DECIMAL(10, 2)
) PARTITION BY RANGE (order_date);
