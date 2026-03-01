def measure_cache_benefit(func,
                         cache_enabled=True):
    # Execute with cache
    start_time = time.time()
    cache_result = func(use_cache=True)
    cache_time = time.time() - start_time
    if not cache_enabled:
        return cache_result, cache_time, cache_time
# Execute without cache
start_time = time.time()
no_cache_result = func(use_cache=False)
no_cache_time = time.time() - start_time
# Calculate improvement
improvement = (
    (no_cache_time - cache_time) /
    no_cache_time * 100
)
return cache_result, cache_time, improvement
