def max_subarray_xor(nums):
    if not nums:
        return 0
        
    max_xor = float('-inf')
    prefix_xor = 0
    
    for num in nums:
        prefix_xor ^= num
        max_xor = max(max_xor, prefix_xor)
        
        curr_xor = prefix_xor
        for i in range(len(nums)):
            curr_xor ^= nums[i]
            max_xor = max(max_xor, curr_xor)
            
    return max_xor