# Remove Duplicates from Sorted Array
def removeDuplicates(nums):
    if not nums:
        return 0
        
    slow = 0  # Points to last unique element
    
    for fast in range(1, len(nums)):
        if nums[fast] != nums[slow]:
            slow += 1
            nums[slow] = nums[fast]
    
    return slow + 1