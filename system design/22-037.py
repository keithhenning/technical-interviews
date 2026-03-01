# Phase 3: Multi-level caching with event-based invalidation
class UserPreferenceService:
    def __init__(self, local_cache, redis_client, database,
    event_bus):
        self.local_cache = local_cache  # In-memory cache
        self.redis = redis_client
                                        # Distributed cache
        self.db = database
                                        # Database access
        self.events = event_bus
                                        # Event system
        # Subscribe to relevant events
        self.events.subscribe('user.preferences.updated',
        self.handle_preference_update)
    def get_preferences(self, user_id):
        """Get user preferences with multi-level caching"""
        # Check local cache first (fastest)
        local_key = f"prefs:{user_id}"
        if local_key in self.local_cache:
            return self.local_cache[local_key]
        # Check Redis next
        redis_key = f"user:prefs:{user_id}"
        cached = self.redis.get(redis_key)
        if cached:
            # Update local cache
            preferences = json.loads(cached)
            self.local_cache[local_key] = preferences
            return preferences
        # Cache miss - fetch from database
        preferences = self.db.fetch_preferences(user_id)
        # Update both caches
        self.redis.setex(redis_key, 3600,
        json.dumps(preferences))
        self.local_cache[local_key] = preferences
        return preferences
    def update_preferences(self, user_id, new_preferences):
    """Update user preferences"""
    # Update database
    self.db.update_preferences(user_id, new_preferences)
    # Publish event for cache invalidation
    self.events.publish('user.preferences.updated', {
        'user_id': user_id,
        'timestamp': time.time()
    })
    return new_preferences
def handle_preference_update(self, event):
    """Handle preference update events"""
    user_id = event['user_id']
    # Invalidate local cache
    local_key = f"prefs:{user_id}"
    if local_key in self.local_cache:
        del self.local_cache[local_key]
    # Invalidate Redis cache
    redis_key = f"user:prefs:{user_id}"
    self.redis.delete(redis_key)
