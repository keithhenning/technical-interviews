def merge_sort(array):
  """
  Sorts using merge sort algorithm.
  
  Args:
     array: The list to be sorted
     
  Returns:
     A new sorted list
  """
  # Base case: already sorted
  if len(array) <= 1:
     return array
     
  # Divide array into halves
  mid = len(array) // 2
  
  # Recursively sort halves
  left = merge_sort(array[:mid])
  right = merge_sort(array[mid:])
  
  # Merge sorted halves
  return merge(left, right)

def merge(left, right):
  """
  Merges two sorted arrays.
  
  Args:
     left: First sorted array
     right: Second sorted array
     
  Returns:
     New sorted array with all elements
  """
  result = []
  
  # Compare and merge elements
  while left and right:
     result.append(left.pop(0) if left[0] <= right[0] 
                 else right.pop(0))
  
  # Add remaining elements
  return result + left + right

# Example usage
array = [23, 16, 6, 59, 3, 11, 37]
sorted_array = merge_sort(array)
print(sorted_array)  # [3, 6, 11, 16, 23, 37, 59]