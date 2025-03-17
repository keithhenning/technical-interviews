class Cache:
    def __init__(self, capacity):
        self.capacity = capacity
        self.cache = {}
        self.usage = {}
    
    def get(self, key):
        if key in self.cache:
            self.usage[key] += 1
            return self.cache[key]
        return None
    
    def put(self, key, value):
        if len(self.cache) >= self.capacity:
            # Remove least used item
            least_used = min(self.usage.items(), key=lambda x: x[1])[0]
            del self.cache[least_used]
            del self.usage[least_used]
        
        self.cache[key] = value
        self.usage[key] = 1