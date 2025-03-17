def quick_sort(arr):
   """Sort array using quicksort algorithm."""
   # Base case
   if len(arr) <= 1:
      return arr
   
   # Choose pivot
   pivot = arr[-1]
   left = []
   right = []
   
   # Partition array
   for elem in arr[:-1]:
      if elem <= pivot:
         left.append(elem)
      else:
         right.append(elem)
   
   # Recursively sort
   return quick_sort(left) + [pivot] + quick_sort(right)

def quick_sort_in_place(arr, low=0, high=None):
   """Sort array in-place using quicksort."""
   # Initialize high if not provided
   if high is None:
      high = len(arr) - 1
   
   def partition(low, high):
      """Partition array segment."""
      pivot = arr[high]
      i = low - 1
      
      for j in range(low, high):
         if arr[j] <= pivot:
            i += 1
            arr[i], arr[j] = arr[j], arr[i]
      
      arr[i + 1], arr[high] = arr[high], arr[i + 1]
      return i + 1
   
   # Recursive sorting
   if low < high:
      pi = partition(low, high)
      quick_sort_in_place(arr, low, pi - 1)
      quick_sort_in_place(arr, pi + 1, high)
   
   return arr

# Demonstrate quick sort variants
if __name__ == "__main__":
   # Test cases
   test_cases = [
      [23, 16, 6, 59, 3, 11, 37],
      [1, 2, 3, 4, 5],
      [5, 4, 3, 2, 1],
      []
   ]
   
   print("Standard Quick Sort:")
   for case in test_cases:
      orig = case.copy()
      sorted_case = quick_sort(orig)
      print(f"Original: {orig}")
      print(f"Sorted:   {sorted_case}\n")
   
   print("In-Place Quick Sort:")
   for case in test_cases:
      orig = case.copy()
      quick_sort_in_place(orig)
      print(f"Original: {case}")
      print(f"Sorted:   {orig}\n")