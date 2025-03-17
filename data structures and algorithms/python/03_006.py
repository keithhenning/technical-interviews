def bubble_sort(arr):
   """Sort list in-place using bubble sort algorithm.
   
   Time Complexity: O(n²) worst/avg, O(n) best
   Space Complexity: O(1)
   """
   n = len(arr)
   for i in range(n):
      # Track if any swaps occur
      swapped = False
      
      # Reduce comparisons in each pass
      for j in range(0, n - i - 1):
         # Swap if elements in wrong order
         if arr[j] > arr[j + 1]:
            arr[j], arr[j + 1] = arr[j + 1], arr[j]
            swapped = True
      
      # Exit if no swaps (array sorted)
      if not swapped:
         break

# Demonstrate bubble sort functionality
if __name__ == "__main__":
   # Test cases
   test_cases = [
      [64, 34, 25, 12, 22, 11, 90],  # Unsorted
      [1, 2, 3, 4, 5],                # Already sorted
      [5, 4, 3, 2, 1]                 # Reverse sorted
   ]
   
   for case in test_cases:
      orig = case.copy()
      bubble_sort(case)
      print(f"Original: {orig}")
      print(f"Sorted:   {case}\n")