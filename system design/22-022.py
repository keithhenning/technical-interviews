class MultiLevelCache:
    def __init__(self, l1_cache, l2_cache):
        # Fast, limited capacity (local memory)
        self.l1 = l1_cache
        # Slower, larger capacity (Redis)
        self.l2 = l2_cache
    def get(self, key):
        # Try L1 first
        value = self.l1.get(key)
    if value is not None:
        return value
    # Try L2
    value = self.l2.get(key)
    if value is not None:
        # Update L1 for future requests
        self.l1.set(key, value)
        return value
    return None
def set(self, key, value, l1_expire=60,
        l2_expire=3600):
    # Set in both caches
    self.l1.set(key, value, expire=l1_expire)
    self.l2.set(key, value, expire=l2_expire)
