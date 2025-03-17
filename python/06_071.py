def bucket_sort(arr, k):
    # Create k+1 buckets (for numbers 0 to k)
    count = [0] * (k + 1)
    
    # Count occurrences of each element
    for num in arr:
        count[num] += 1
    
    # Reconstruct the sorted array
    sorted_arr = []
    for i in range(k + 1):
        sorted_arr.extend([i] * count[i])
    
    return sorted_arr