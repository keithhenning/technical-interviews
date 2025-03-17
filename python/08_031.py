def has_nearby_duplicates(nums, k):

    window = set()
    
    for i, num in enumerate(nums):
        # Remove element outside window
        if i >= k:
            window.remove(nums[i - k])
            
        # Check if current element is in window
        if num in window:
            return True
            
        window.add(num)
    
    return False