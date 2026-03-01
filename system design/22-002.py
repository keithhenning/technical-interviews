import time
class WriteThroughCache:
    def __init__(self):
        self.cache = {}
        self.database = {}
    def write(self, key, value):
        """
        Write to cache AND database synchronously
        """
        # 1. Write to cache
        self.cache[key] = value
        # 2. Write to database (blocks)
        time.sleep(0.1)  # Simulate DB latency
        self.database[key] = value
        # 3. Only return after both complete
        print(f"Wrote {key} to both cache and "
              "database")
        return True
    def read(self, key):
        """Read from cache first"""
        # Check cache
        if key in self.cache:
            print(f"Cache hit for {key}")
            return self.cache[key]
        # Cache miss - load from database
        print(f"Cache miss for {key}")
        if key in self.database:
            value = self.database[key]
            self.cache[key] = value
            return value
        return None
# Usage
cache = WriteThroughCache()
# Slower - waits for DB write
cache.write("user:1", "Alice")
# Fast - cache hit
user = cache.read("user:1")
