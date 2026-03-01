def get_with_lock(cache, key, regenerate_func):
    # Try to get from cache
    result = cache.get(key)
    if result:
    return result
# Use distributed lock to prevent
# multiple regenerations
lock_key = f"lock:{key}"
# Add only succeeds if key doesn't exist
if cache.add(lock_key, "locked", expire=30):
    try:
        # Regenerate the value
        result = regenerate_func()
        # Store in cache
        cache.set(key, result, expire=3600)
        return result
    finally:
        # Release the lock
        cache.delete(lock_key)
else:
    # Someone else is regenerating, wait
    time.sleep(0.1)
    return get_with_lock(
        cache, key, regenerate_func
    )
