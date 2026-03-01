def track_hit_rate(cache_name):
    hits = metrics.counter(f"{cache_name}.hits")
    misses = metrics.counter(
        f"{cache_name}.misses"
    )
    # Calculate hit rate
    total = hits + misses
    hit_rate = (
        (hits / total) if total > 0 else 0
    )
    metrics.gauge(
        f"{cache_name}.hit_rate",
        hit_rate
    )
