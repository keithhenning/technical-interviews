class RealTimeAnalyticsCache:
    def __init__(self, redis_client):
        self.redis = redis_client
    def increment_counter(self, metric, value=1):
        """Increment counter for metrics"""
        # Get current timestamp at minute
        timestamp = int(time.time() / 60) * 60
        key = f"stats:{metric}:{timestamp}"
        # Increment the counter
        self.redis.incrby(key, value)
        # Set expiry for cleanup (7 days)
        self.redis.expire(key, 60 * 60 * 24 * 7)
    def get_timeseries(self, metric, minutes=60):
        """Get time series data for metric"""
        now = int(time.time() / 60) * 60
        start_time = now - (minutes * 60)
        # Collect data points
        series = []
        for timestamp in range(
            start_time, now + 60, 60
        ):
            key = f"stats:{metric}:{timestamp}"
            value = self.redis.get(key)
            value = int(value) if value else 0
            series.append({
                'timestamp': timestamp,
            'value': value
        })
    return series
def get_current_rate(self, metric,
                    window_minutes=5):
    """Calculate current rate of events"""
    series = self.get_timeseries(
        metric, minutes=window_minutes
    )
    total = sum(
        point['value'] for point in series
    )
    # Events per minute
    return total / window_minutes
