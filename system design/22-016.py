def monitor_cache_size(redis_client):
    # Get memory stats
    info = redis_client.info(section="memory")
    # Track usage
    metrics.gauge(
        "cache.memory.used",
        info['used_memory']
    )
    metrics.gauge(
        "cache.memory.peak",
        info['used_memory_peak']
    )
    # Calculate fragmentation ratio
    metrics.gauge(
        "cache.memory.fragmentation",
        info['mem_fragmentation_ratio']
)
