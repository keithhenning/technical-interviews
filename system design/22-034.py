class ObservableCache:
    def __init__(self, redis_client, metrics):
        self.redis = redis_client
        self.metrics = metrics
        self.start_time = time.time()
        # Initialize counters
        self.reset_stats()
    def reset_stats(self):
        self.hits = 0
        self.misses = 0
        self.errors = 0
        self.sets = 0
        self.invalidations = 0
    def get(self, key):
        start = time.time()
        try:
            value = self.redis.get(key)
            # Track hit/miss
            if value:
                self.hits += 1
                self.metrics.increment(
                    "cache.hits",
                    tags={"key": key}
                )
            else:
                self.misses += 1
                self.metrics.increment(
                    "cache.misses",
            tags={"key": key}
        )
    # Track latency
    latency = time.time() - start
    self.metrics.timing(
        "cache.get.latency",
        latency,
        tags={"key": key}
    )
    return value
except Exception as e:
    self.errors += 1
    self.metrics.increment(
        "cache.errors",
        tags={
            "operation": "get",
            "key": key
        }
    )
    logging.error(f"Cache get error: {e}")
    return None
