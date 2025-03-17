import time

class CacheItem:
    def __init__(self, key, value):
        self.key = key
        self.value = value
        self.frequency = 1
        self.last_access = time.time()
    
    def access(self):
        self.frequency += 1
        self.last_access = time.time()
        
    def get_score(self, current_time):
        """Calculate item's value based on frequency and recency."""
        # Higher frequency and recency = higher score
        recency_score = 1.0 / (1.0 + (current_time - self.last_access))
        return self.frequency * recency_score

class IntelligentCache:
    def __init__(self, capacity):
        self.capacity = capacity
        self.cache = {}  # key -> CacheItem
    
    def get(self, key):
        if key not in self.cache:
            return None
        
        # Update frequency and last access time
        self.cache[key].access()
        return self.cache[key].value
    
    def put(self, key, value):
        # If key already exists, update value and access info
        if key in self.cache:
            self.cache[key].value = value
            self.cache[key].access()
            return
        
        # If cache is full, evict least valuable item
        if len(self.cache) >= self.capacity:
            self._evict()
        
        # Add new item
        self.cache[key] = CacheItem(key, value)
    
    def _evict(self):
        """Evict the item with the lowest score."""
        if not self.cache:
            return
        
        current_time = time.time()
        min_score = float('inf')
        min_key = None
        
        for key, item in self.cache.items():
            score = item.get_score(current_time)
            if score < min_score:
                min_score = score
                min_key = key
        
        if min_key:
            del self.cache[min_key]