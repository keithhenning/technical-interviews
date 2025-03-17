from collections import deque

def k_sort(arr, k):
   # Get length of input array
   n = len(arr)
   result = []
   
   # Create buckets for possible values
   min_val, max_val = min(arr), max(arr)
   buckets = [deque() for _ in range(k+1)]
   
   # Process elements in order
   for i in range(n):
      # Place elements in appropriate buckets
      bucket_idx = min(k, i)
      buckets[bucket_idx].append(arr[i])
      
      # Extract when k+1 buckets are filled
      if i >= k:
         # Find minimum non-empty bucket
         min_bucket = min(
            range(k+1),
            key=lambda x: float('inf') 
            if not buckets[x] else buckets[x][0]
         )
         result.append(buckets[min_bucket].popleft())
   
   # Extract remaining elements
   while any(buckets):
      min_bucket = min(
         range(k+1),
         key=lambda x: float('inf') 
         if not buckets[x] else buckets[x][0]
      )
      result.append(buckets[min_bucket].popleft())
   
   return result