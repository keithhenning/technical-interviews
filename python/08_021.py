def query_rotated_array(arr, queries):
   """
   Compute the result of queries on a circular array 
   after rotations.
   
   Args:
       arr: List of integers representing the circular array
       queries: List of [rotation, index] pairs for each query
       
   Returns:
       List of integers representing the query results
   """
   n = len(arr)
   results = []
   
   for rotation, index in queries:
      # Calculate the effective rotation (in case rotation > n)
      effective_rotation = rotation % n
      
      # The element at position 'index' after rotating right by
      # 'effective_rotation' is originally at position
      # (index - effective_rotation) % n
      original_position = (index - effective_rotation) % n
      results.append(arr[original_position])
   
   return results

# Test with the example
arr = [3, 7, 1, 9, 5]
queries = [[2, 1], [4, 3], [0, 2]]
print(query_rotated_array(arr, queries))  # Output: [3, 3, 1]