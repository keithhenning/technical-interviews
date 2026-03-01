def get_with_semaphore(cache, key,
                       regenerate_func):
    """
    Get cached value with semaphore
    to prevent stampedes
    """
    # Try cache first
    value = cache.get(key)
    if value:
        return value
    # Cache miss - use semaphore
    semaphore_key = f"sem:{key}"
    # Try to acquire semaphore
    # Returns False if key exists
    if cache.add(semaphore_key, "1",
                 expire=30):
        try:
            # We got semaphore, regenerate
            value = regenerate_func()
            # Cache the value
            cache.set(key, value, expire=3600)
            return value
        finally:
            # Always release semaphore
            cache.delete(semaphore_key)
    else:
        # Someone else regenerating,
        # wait briefly then retry
        time.sleep(0.1)
        # Retry cache after waiting
    value = cache.get(key)
    if value:
        return value
    # If still not cached,
    # wait for semaphore
    for _ in range(10):  # Try 10 times
        time.sleep(0.3)
        # Check cache again
        value = cache.get(key)
        if value:
            return value
# Fallback: regenerate anyway
return regenerate_func()
