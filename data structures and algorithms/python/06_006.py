def insertion_sort(arr):
   """Sort array using insertion sort algorithm."""
   # Iterate through array starting from second element
   for i in range(1, len(arr)):
      # Current element to insert
      key = arr[i]
      
      # Find insertion point
      j = i - 1
      while j >= 0 and arr[j] > key:
         arr[j + 1] = arr[j]
         j -= 1
      
      # Place element in correct position
      arr[j + 1] = key
   
   return arr

# Demonstrate insertion sort
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
      sorted_case = insertion_sort(orig)
      print(f"Original: {orig}")
      print(f"Sorted:   {sorted_case}\n")