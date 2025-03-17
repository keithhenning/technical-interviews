def test_boundaries(arr, k):
    # Test first window
    first_window = maxSumSubarray(arr[:k], k)
    # Test last window
    last_window = maxSumSubarray(arr[-k:], k)