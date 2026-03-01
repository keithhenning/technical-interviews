-- Create partitioned table
CREATE TABLE orders (
    order_id INT,
    region VARCHAR(20),
    amount DECIMAL(10,2)
) PARTITION BY LIST (region);
-- Create partitions
CREATE TABLE orders_north PARTITION OF orders
    FOR VALUES IN ('NY', 'MA', 'CT');
CREATE TABLE orders_south PARTITION OF orders
    FOR VALUES IN ('FL', 'TX', 'GA');
CREATE TABLE orders_west PARTITION OF orders
    FOR VALUES IN ('CA', 'WA', 'OR');
