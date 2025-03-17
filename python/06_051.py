def maxSumSubarray(arr: List[int], k: int) -> int:
    if not arr or len(arr) < k:
        return -1
    
    # Compute sum of first window
    window_sum = sum(arr[:k])
    max_sum = window_sum
    
    # Slide window and update max_sum
    for i in range(k, len(arr)):
        window_sum = window_sum + arr[i] - arr[i - k]
        max_sum = max(max_sum, window_sum)
    
    return max_sum

def test_sliding_window():
    # Test case 1: Basic case
    arr1 = [1, 4, 2, 10, 2, 3, 1, 0, 20]
    k1 = 4
    print(f"Test 1: Window size {k1}")
    print(f"Array: {arr1}")
    print(f"Expected: 24 (sum of window [2, 3, 1, 0])")
    print(f"Result: {maxSumSubarray(arr1, k1)}\n")

    # Test case 2: Window size equals array length
    arr2 = [1, 4, 2, 10]
    k2 = 4
    print(f"Test 2: Window equals array size")
    print(f"Array: {arr2}")
    print(f"Expected: 17")
    print(f"Result: {maxSumSubarray(arr2, k2)}\n")

    # Test case 3: Small array
    arr3 = [1, 2]
    k3 = 3
    print(f"Test 3: Array smaller than window")
    print(f"Array: {arr3}")
    print(f"Expected: -1")
    print(f"Result: {maxSumSubarray(arr3, k3)}\n")

# Run tests
test_sliding_window()