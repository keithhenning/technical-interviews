class EventuallyConsistentCache:
    def __init__(self, redis_client, db_client,
                 event_bus):
        self.redis = redis_client
        self.db = db_client
        self.event_bus = event_bus
    def get(self, key):
        """Get with eventual consistency"""
        # Always try cache first
        data = self.redis.get(key)
        if data:
            return json.loads(data)
        # Cache miss, fetch from database
        data = self.db.get(key)
        # Update cache asynchronously
        if data:
            self.redis.set(key, json.dumps(data))
        return data
    def set(self, key, value):
        """Set with eventual consistency"""
        # Update database
        self.db.set(key, value)
        # Publish update event
        self.event_bus.publish('cache.update', {
            'key': key,
            'operation': 'set',
            'timestamp': time.time()
        })
def handle_events(self, event):
    """Event handler for cache updates"""
    if event['operation'] == 'set':
        key = event['key']
        # Fetch latest from DB
        data = self.db.get(key)
        if data:
            self.redis.set(
                key, json.dumps(data)
            )
    elif event['operation'] == 'delete':
        self.redis.delete(event['key'])
