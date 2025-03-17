def median_of_medians(arr, k):
   """
   Find kth smallest element using
   median-of-medians algorithm.
   
   Args:
      arr (list): Input array
      k (int): Zero-based index to find
   
   Returns:
      Kth smallest element
   
   Time Complexity: O(n)
   Space Complexity: O(n)
   """
   if len(arr) <= 5:
      # Base case: sort small arrays
      return sorted(arr)[k]
   
   # Find medians of 5-element groups
   medians = []
   for i in range(0, len(arr), 5):
      group = arr[i:i+5]
      group_median = sorted(group)[len(group) // 2]
      medians.append(group_median)
   
   # Find median of medians
   pivot = (medians[0] if len(medians) <= 1 
            else median_of_medians(medians, len(medians) // 2))
   
   # Partition array around pivot
   left = [x for x in arr if x < pivot]
   middle = [x for x in arr if x == pivot]
   right = [x for x in arr if x > pivot]
   
   # Recursively find element
   if k < len(left):
      return median_of_medians(left, k)
   elif k < len(left) + len(middle):
      return pivot
   else:
      return median_of_medians(
         right, 
         k - len(left) - len(middle)
      )


# Example usage
if __name__ == "__main__":
   arr = [9, 1, 8, 2, 7, 3, 6, 4, 5]
   
   # Find 4th smallest element
   result = median_of_medians(arr, 3)
   print(f"4th smallest: {result}")
   
   # Find array median
   median_index = len(arr) // 2
   median = median_of_medians(arr, median_index)
   print(f"Median: {median}") // 5