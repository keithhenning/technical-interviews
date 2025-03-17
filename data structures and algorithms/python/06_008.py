def update_sorted_list(sorted_arr, new_item):
   # Append new item and bubble down to correct position
   sorted_arr.append(new_item)
   i = len(sorted_arr) - 1
   
   while i > 0 and sorted_arr[i-1] > sorted_arr[i]:
      # Swap adjacent elements until in correct order
      sorted_arr[i], sorted_arr[i-1] = sorted_arr[i-1], sorted_arr[i]
      i -= 1
   
   return sorted_arr

# Demonstrate list update
if __name__ == "__main__":
   # Test cases
   test_cases = [
      ([1, 3, 5, 7], 4),
      ([2, 4, 6, 8], 1),
      ([10, 20, 30], 25),
      ([], 5)
   ]
   
   for arr, item in test_cases:
      orig = arr.copy()
      updated = update_sorted_list(arr, item)
      print(f"Original: {orig}")
      print(f"New Item: {item}")
      print(f"Updated:  {updated}\n")