def test_performance():
    large_arr = [i % 100 for i in range(1000000)]
    k = 1000
    start_time = time.time()
    result = maxSumSubarray(large_arr, k)
    end_time = time.time()
    print(f"Time taken: {end_time - start_time} seconds")