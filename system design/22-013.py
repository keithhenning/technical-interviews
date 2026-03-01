# Implementation with sliding window
def get_with_sliding_window(
    cache, key, regenerate_func, window_start=0.8
):
    result = cache.get(key)
    expiry = cache.ttl(key)  # Time to live
    # If found and not in expiry window,
    # return immediately
    if (result and
        (expiry < 0 or
         expiry > window_start * 3600)):
        return result
    # In expiry window or not found
    # Regenerate with probability
    if not result or random.random() < 0.1:
        # 10% chance of regeneration
        result = regenerate_func()
        cache.set(key, result, expire=3600)
    return result
