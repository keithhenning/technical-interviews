def median_of_three(arr, low, high):
    mid = (low + high) // 2
    
    # Find median of first, middle, and last elements
    if arr[low] > arr[mid]:
        arr[low], arr[mid] = arr[mid], arr[low]
    if arr[mid] > arr[high]:
        arr[mid], arr[high] = arr[high], arr[mid]
    if arr[low] > arr[mid]:
        arr[low], arr[mid] = arr[mid], arr[low]
    
    # Return the median as pivot (usually at position high-1)
    arr[mid], arr[high-1] = arr[high-1], arr[mid]
    return arr[high-1]