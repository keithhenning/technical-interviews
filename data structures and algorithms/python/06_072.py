def bucket_sort_float(arr):
    n = len(arr)
    buckets = [[] for _ in range(n)]
    
    # Place elements into buckets
    for num in arr:
        bucket_idx = int(n * num)
        buckets[bucket_idx].append(num)
    
    # Sort individual buckets
    for bucket in buckets:
        # Can use insertion sort for small buckets
        bucket.sort()
    
    # Concatenate all buckets
    result = []
    for bucket in buckets:
        result.extend(bucket)
    
    return result