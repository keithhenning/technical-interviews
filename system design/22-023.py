class SegmentedCache:
    def __init__(self, redis_client):
        self.redis = redis_client
        # Define cache segments with TTLs
        self.segments = {
            'product': 3600,
                                   # 1 hour
            'user': 7200,
                                   # 2 hours
            'search': 300,
                                   # 5 minutes
            'recommendation': 900  # 15 minutes
        }
    def get(self, segment, key):
        full_key = f"{segment}:{key}"
        return self.redis.get(full_key)
def set(self, segment, key, value):
    full_key = f"{segment}:{key}"
    ttl = self.segments.get(
        segment, 300  # Default 5 min
    )
    self.redis.setex(full_key, ttl, value)
def clear_segment(self, segment):
    """Clear all keys in a segment"""
    cursor = 0
    while True:
        cursor, keys = self.redis.scan(
            cursor, f"{segment}:*", 100
        )
        if keys:
            self.redis.delete(*keys)
        if cursor == 0:
            break
