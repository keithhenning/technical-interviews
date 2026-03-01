def generate_cache_key(resource_type, id,
                       params=None, version="v1"):
    # Base key with resource type and ID
    key = f"{resource_type}:{id}:{version}"
    # Add sorted parameters for consistency
    if params:
        param_str = ":".join(
            f"{k}={v}" for k, v in
            sorted(params.items())
        )
        key = f"{key}:{param_str}"
    return key
