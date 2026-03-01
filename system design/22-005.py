import time
import threading
class RefreshAheadCache:
    def __init__(self, ttl=10):
        self.cache = {}
        self.timestamps = {}  # Track cached times
        self.ttl = ttl  # Time to live in seconds
        self.database = {
            "user:1": "Alice",
            "user:2": "Bob"
        }
    def get(self, key):
        """
        Get value and trigger refresh if needed
        """
        current_time = time.time()
        # Check if in cache and not expired
        if (key in self.cache and
            current_time - self.timestamps[key] <
            self.ttl):
            age = current_time - self.timestamps[key]
            # If 80% of TTL passed, refresh
            if age > (self.ttl * 0.8):
                print(f"Triggering background "
                      f"refresh for {key}")
                threading.Thread(
                    target=self._refresh,
                    args=(key,),
                    daemon=True
                ).start()
            return self.cache[key]
        # Cache miss or expired
        return self._load_from_db(key)
    def _load_from_db(self, key):
        """Load data from database"""
        time.sleep(0.1)  # Simulate DB latency
        if key in self.database:
            value = self.database[key]
            self.cache[key] = value
            self.timestamps[key] = time.time()
            print(f"Loaded {key} from database")
            return value
        return None
    def _refresh(self, key):
        """Background refresh of cache entry"""
        print(f"Refreshing {key} in background...")
        self._load_from_db(key)
# Usage
cache = RefreshAheadCache(ttl=10)
# First access - loads from DB
user = cache.get("user:1")
# Wait 8 seconds (80% of 10 second TTL)
time.sleep(8)
# This triggers background refresh
user = cache.get("user:1")
# After refresh completes, cache is fresh
time.sleep(3)
user = cache.get("user:1")
