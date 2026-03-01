class WriteAroundCache:
    def __init__(self):
        self.cache = {}
        self.database = {}
    def write(self, key, value):
        """
        Write directly to database, skip cache
        """
        # Write to database
        self.database[key] = value
        # Remove from cache (invalidate)
        if key in self.cache:
            del self.cache[key]
        return True
    def read(self, key):
        """Read with cache check"""
        # Check cache first
        if key in self.cache:
            print(f"Cache hit for {key}")
            return self.cache[key]
        # Cache miss - read from database
        print(f"Cache miss for {key}")
        if key in self.database:
            value = self.database[key]
            self.cache[key] = value  # Populate
            return value
        return None
# Usage
cache = WriteAroundCache()
# Writes to DB, not cache
cache.write("product:1", "Laptop")
# Cache miss, loads from DB
item = cache.read("product:1")
# Cache hit, fast read
item = cache.read("product:1")
