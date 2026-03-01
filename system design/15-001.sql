-- Example: Partitioning a logs table by month
CREATE TABLE logs (
    id BIGINT,
    timestamp TIMESTAMP,
    message TEXT
) PARTITION BY RANGE (timestamp);
CREATE TABLE logs_2024_01 PARTITION OF logs
    FOR VALUES FROM ('2024-01-01') TO ('2024-02-01');
CREATE TABLE logs_2024_02 PARTITION OF logs
    FOR VALUES FROM ('2024-02-01') TO ('2024-03-01');
