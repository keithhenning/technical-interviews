class CacheAsideCache:
    def __init__(self):
        self.cache = {}
        self.database = {
            "user:1": "Alice",
            "user:2": "Bob",
            "user:3": "Charlie"
        }
    def get(self, key):
        """Application manages cache logic"""
        # 1. Check cache first
        if key in self.cache:
            print(f"Cache hit for {key}")
            return self.cache[key]
        # 2. Cache miss - load from database
        print(f"Cache miss for {key}")
        value = self.database.get(key)
        # 3. Populate cache for next time
        if value:
            self.cache[key] = value
        return value
    def write(self, key, value):
        """Write to database, then update cache"""
        # Write to database first
        self.database[key] = value
        # Update cache
        self.cache[key] = value
        return True
# Usage
cache = CacheAsideCache()
# Cache miss, loads from DB
user = cache.get("user:1")
# Cache hit, fast read
user = cache.get("user:1")
# Updates both DB and cache
cache.write("user:4", "David")
# Cache hit
user = cache.get("user:4")
