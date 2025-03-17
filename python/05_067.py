class Solution(object):
    def twoSum(self, nums, target):
        seen = {}  # num -> index
        for i, num in enumerate(nums):
            complement = target - num
            if complement in seen:
                return [seen[complement], i]
            seen[num] = i
        return []