def bucket_sort(arr):
   # Return empty array if input is empty
   if not arr:
      return arr
   
   # Create buckets using array length as bucket count
   max_val, min_val = max(arr), min(arr)
   bucket_count = len(arr)
   buckets = [[] for _ in range(bucket_count)]
   
   # Distribute elements into buckets
   for num in arr:
      # Calculate bucket index for this element
      index = int((num - min_val) * (bucket_count - 1) / 
                 (max_val - min_val))
      buckets[index].append(num)
   
   # Sort individual buckets
   for bucket in buckets:
      bucket.sort()
   
   # Concatenate all buckets into final result
   sorted_arr = []
   for bucket in buckets:
      sorted_arr.extend(bucket)
   
   return sorted_arr

# Example usage
arr = [0.897, 0.565, 0.656, 0.1234, 0.665, 0.3434]
sorted_arr = bucket_sort(arr)
print(sorted_arr)