def good_hash(key):
    # Use built-in hash for strings
    if isinstance(key, str):
        return hash(key)
    # Custom hash for tuples
    if isinstance(key, tuple):
        return sum(hash(item) for item in key)