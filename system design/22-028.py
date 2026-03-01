class StronglyConsistentCache:
    def __init__(self, redis_client, db_client):
        self.redis = redis_client
        self.db = db_client
        self.lock_timeout = 10  # seconds
def get(self, key):
    """Get with strong consistency"""
    # Try cache first
    data = self.redis.get(key)
    if data:
        return json.loads(data)
    # Acquire lock for thundering herd
    lock_key = f"lock:{key}"
    lock_id = str(uuid.uuid4())
    acquired = self.redis.set(
        lock_key, lock_id,
        nx=True, ex=self.lock_timeout
    )
    if not acquired:
        # Someone else fetching, wait
        time.sleep(0.1)
        return self.get(key)
    try:
        # Fetch from database
        data = self.db.get(key)
        # Update cache atomically
        if data:
            self.redis.set(
                key, json.dumps(data)
            )
        return data
    finally:
        # Release lock if we still own it
        if self.redis.get(lock_key) == lock_id:
            self.redis.delete(lock_key)
