def get_data_resilient(key, cache, database):
    """
    Resilient data access
    with circuit breaker pattern
    """
    try:
        # Try cache first
        value = cache.get(key)
        if value:
            return value
    except Exception as e:
        # Log but continue on cache failure
        logging.error(f"Cache error: {e}")
    # Fallback to database
    return database.get(key)
