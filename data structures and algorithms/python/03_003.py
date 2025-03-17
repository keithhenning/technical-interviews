def find_maximum(arr):
  """
  Finds the maximum value in an array/list.
  
  Args:
     arr: A list of comparable elements
  
  Returns:
     The maximum value found in the array
  
  Raises:
     IndexError: If the input array is empty
  """
  # Initialize max with first element
  max_value = arr[0]
  
  # Iterate through each element
  for num in arr:
     # If current element is greater
     if num > max_value:
        # Update max_value
        max_value = num
  
  # Return the maximum value
  return max_value

# Example usage
numbers = [3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5]
print(find_maximum(numbers))  # Output: 9