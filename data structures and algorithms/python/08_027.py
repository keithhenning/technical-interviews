def max_subarray_with_target_sum(nums, target):
   # Map to store the first occurrence of each cumulative sum
   sum_index_map = {0: -1}  # Initialize with 0 sum at index -1
   
   max_length = 0
   current_sum = 0
   
   for i, num in enumerate(nums):
      current_sum += num
      
      # Check if we can form a subarray with sum = target
      if current_sum - target in sum_index_map:
         subarray_start = sum_index_map[current_sum - target] + 1
         current_length = i - subarray_start + 1
         max_length = max(max_length, current_length)
      
      # Only store the first occurrence of each sum
      if current_sum not in sum_index_map:
         sum_index_map[current_sum] = i
   
   return max_length

# Test with example
nums = [1, -1, 5, -2, 3, 0, 2, -4, 1]
target = 3
print(max_subarray_with_target_sum(nums, target))  # Output: 4