class CausallyConsistentCache:
    def __init__(self, redis_client, db_client):
        self.redis = redis_client
        self.db = db_client
    def get(self, key, version=None):
        """Get with causal consistency"""
        # If version specified, ensure we have it
        if version:
            cached_data = self.redis.get(key)
            if cached_data:
                data = json.loads(cached_data)
                if data.get('version', 0) >= version:
                    return data
        # Fetch from database
    data = self.db.get(key)
    # Update cache with version
    if data:
        self.redis.set(key, json.dumps(data))
    return data
def set(self, key, value):
    """Set with causal consistency"""
    # Get current version
    current = self.db.get(key)
    next_version = (
        (current.get('version', 0) + 1)
        if current else 1
    )
    # Update value with new version
    value['version'] = next_version
    # Update database
    self.db.set(key, value)
    # Return new version for tracking
    return next_version
