def binary_search(arr, target):
  """
  Performs binary search on a sorted array.
  
  Args:
     arr: A sorted list of elements
     target: The element to find
  
  Returns:
     Index of target if found, otherwise -1
  """
  # Initialize pointers for boundaries
  left, right = 0, len(arr) - 1
  
  # Search while boundaries haven't crossed
  while left <= right:
     # Calculate middle index
     mid = (left + right) // 2
     
     # Found target
     if arr[mid] == target:
        return mid
     # Target in right half
     elif arr[mid] < target:
        left = mid + 1
     # Target in left half
     else:
        right = mid - 1
  
  # Target not found
  return -1

# Example usage
numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
target = 7
index = binary_search(numbers, target)

# Display result
if index != -1:
  print(f"Element {target} found at index {index}")
else:
  print(f"Element {target} not found in the list")