def find_minimum(nums):

    left, right = 0, len(nums) - 1
    
    # Already sorted case
    if nums[left] <= nums[right]:
        return nums[left]
    
    while left < right:
        mid = left + (right - left) // 2
        
        # If mid is greater than right, minimum is in right half
        if nums[mid] > nums[right]:
            left = mid + 1
        # If mid is less than right, minimum is in left half
        # (including mid)
        else:
            right = mid
    
    return nums[left]