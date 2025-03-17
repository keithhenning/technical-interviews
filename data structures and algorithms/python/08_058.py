def kth_ancestral_element(arrays, k):
  # Define boundaries for binary search
  left = min(array[0] for array in arrays if array)
  right = max(array[-1] for array in arrays if array)
  
  while left < right:
     mid = (left + right) // 2
     
     # Count ancestral elements less than or equal to mid
     count = 0
     for array in arrays:
        # Binary search to find position of first element > mid
        pos = binary_search(array, mid)
        count += pos
     
     if count < k:
        left = mid + 1
     else:
        right = mid
        
  return left

def binary_search(array, target):
  left, right = 0, len(array)
  
  while left < right:
     mid = (left + right) // 2
     if array[mid] <= target:
        left = mid + 1
     else:
        right = mid
        
  return left  # Returns count of elements <= target