def next_greater_element(nums):
  # Initialize result with -1 for no greater element
  result = [-1] * len(nums)
  stack = []  # Monotonic stack
  
  for i in range(len(nums)):
     # Pop and update for elements smaller than current
     while stack and nums[i] > nums[stack[-1]]:
        popped_index = stack.pop()
        result[popped_index] = nums[i]
     
     # Push current index to stack
     stack.append(i)
  
  return result

# Example usage
nums = [4, 5, 2, 10, 8]
print(next_greater_element(nums))