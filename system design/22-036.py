# Phase 2: Redis-based caching
def get_user_preferences(user_id, redis_client):
    """Fetch user preferences with Redis caching"""
    cache_key = f"user:prefs:{user_id}"
    # Try cache first
    cached = redis_client.get(cache_key)
    if cached:
        return json.loads(cached)
    # Cache miss - fetch from database
    preferences = database.fetch_preferences(user_id)
    # Cache for future
    redis_client.setex(cache_key, 3600,
    json.dumps(preferences))
    return preferences
