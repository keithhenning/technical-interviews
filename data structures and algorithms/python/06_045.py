# Sort Colors (Dutch National Flag problem)
def sortColors(nums):
    low = curr = 0
    high = len(nums) - 1
    
    while curr <= high:
        if nums[curr] == 0:
            nums[low], nums[curr] = nums[curr], nums[low]
            low += 1
            curr += 1
        elif nums[curr] == 2:
            nums[curr], nums[high] = nums[high], nums[curr]
            high -= 1
        else:
            curr += 1