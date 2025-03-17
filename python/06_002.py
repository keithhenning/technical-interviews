def merge_sort(arr):
   """Sort array using merge sort algorithm."""
   # Base case
   if len(arr) <= 1:
      return arr
   
   # Divide input array
   mid = len(arr) // 2
   left = arr[:mid]
   right = arr[mid:]
   
   # Recursively sort halves
   left = merge_sort(left)
   right = merge_sort(right)
   
   # Merge sorted halves
   return merge(left, right)

def merge(left, right):
   """Merge two sorted arrays."""
   result = []
   i = j = 0
   
   # Compare and merge elements
   while i < len(left) and j < len(right):
      if left[i] <= right[j]:
         result.append(left[i])
         i += 1
      else:
         result.append(right[j])
         j += 1
   
   # Append remaining elements
   result.extend(left[i:])
   result.extend(right[j:])
   return result

# Demonstrate merge sort
if __name__ == "__main__":
   # Test cases
   test_cases = [
      [23, 16, 6, 59, 3, 11, 37],
      [1, 2, 3, 4, 5],
      [5, 4, 3, 2, 1],
      []
   ]
   
   for case in test_cases:
      orig = case.copy()
      sorted_case = merge_sort(case)
      print(f"Original: {orig}")
      print(f"Sorted:   {sorted_case}\n")