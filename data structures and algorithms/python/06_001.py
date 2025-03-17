def bubble_sort(arr):
  """Sort an array using bubble sort algorithm."""
  n = len(arr)
  # Number of passes
  for i in range(n):
     # Flag to optimize when array is already sorted
     swapped = False
     
     # Look at each adjacent pair
     for j in range(0, n - i - 1):
        # Swap if in wrong order
        if arr[j] > arr[j + 1]:
           arr[j], arr[j + 1] = arr[j + 1], arr[j]
           swapped = True
     
     # Exit if array is sorted
     if not swapped:
        break
  
  return arr

# Test the function
numbers = [23, 16, 6, 59, 3, 11, 37]
print("Original array:", numbers)
sorted_numbers = bubble_sort(numbers.copy())
print("Sorted array:", sorted_numbers)