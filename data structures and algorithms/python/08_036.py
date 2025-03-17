def has_frequency_threshold(nums, k):

    counter = {}
    
    for num in nums:
        counter[num] = counter.get(num, 0) + 1
        if counter[num] >= k:
            return True
    
    return False