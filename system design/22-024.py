class ReliableWriteThroughCache:
    def __init__(self, redis_client,
                 database_client, retry_limit=3):
        self.redis = redis_client
        self.db = database_client
        self.retry_limit = retry_limit
    def update(self, key, value):
        """
        Update both cache and database
        with retry mechanism
        """
        # Update database first
db_success = False
retry_count = 0
while (not db_success and
       retry_count < self.retry_limit):
    try:
        self.db.update(key, value)
        db_success = True
    except Exception as e:
        retry_count += 1
        logging.error(
            f"Database update failed "
            f"(attempt {retry_count}): {e}"
        )
        # Exponential backoff
        time.sleep(0.5 * retry_count)
if not db_success:
    raise Exception(
        f"Failed to update database "
        f"after {self.retry_limit} attempts"
    )
# Update cache after DB success
cache_success = False
retry_count = 0
while (not cache_success and
       retry_count < self.retry_limit):
    try:
        self.redis.set(
            key, json.dumps(value)
        )
        cache_success = True
    except Exception as e:
        retry_count += 1
        logging.error(
            f"Cache update failed "
            f"(attempt {retry_count}): {e}"
        )
# Shorter backoff for cache
time.sleep(0.2 * retry_count)
