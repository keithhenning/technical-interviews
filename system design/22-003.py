import threading
import time
import queue
class WriteBehindCache:
    def __init__(self):
        self.cache = {}  # In-memory cache
        self.database = {}  # Simulated database
        self.write_queue = queue.Queue()
        # Start background thread
        self.worker = threading.Thread(
            target=self._background_writer,
            daemon=True
        )
        self.worker.start()
    def write(self, key, value):
        """
        Write to cache immediately,
        queue DB write
        """
        # Fast: write to cache
        self.cache[key] = value
        # Queue for later DB write
        self.write_queue.put((key, value))
        return True  # Returns immediately
    def _background_writer(self):
        """Background thread writes to database"""
        while True:
            key, value = self.write_queue.get()
            time.sleep(0.1)  # Simulate DB latency
            self.database[key] = value
            print(f"Wrote {key} to database")
# Usage
cache = WriteBehindCache()
# Returns instantly
cache.write("user:123", "Alice")
# Wait for background write
time.sleep(0.5)
