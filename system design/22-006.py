class SimpleCache:
    def __init__(self):
        self.cache = {}
        self.expiry_times = {}
    def get(self, key):
        if key in self.cache:
            # Check if expired
            if (key in self.expiry_times and
                time.time() >
                self.expiry_times[key]):
                del self.cache[key]
                del self.expiry_times[key]
                return None
            return self.cache[key]
        return None
    def set(self, key, value, expiry=None):
        self.cache[key] = value
        if expiry:
            self.expiry_times[key] = (
                time.time() + expiry
            )
