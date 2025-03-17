def merge(intervals):
  # Handle empty input case
  if not intervals:
     return []
  
  # Sort intervals by start time
  intervals.sort(key=lambda x: x[0])
  
  # Initialize result with first interval
  result = [intervals[0]]
  
  # Iterate through remaining intervals
  for current in intervals[1:]:
     # Get the last interval from result list
     last_merged = result[-1]
     
     # Check if current interval overlaps
     if current[0] <= last_merged[1]:
        # Merge overlapping intervals
        last_merged[1] = max(last_merged[1], 
                            current[1])
     else:
        # If no overlap, add current interval
        result.append(current)
  
  return result

def test_merge_python():
  # Test case with intervals
  intervals = [[1,3],[2,6],[8,10],[15,18]]
  result = merge(intervals)
  print("Python Result:", result)
  # Expected output: [[1,6],[8,10],[15,18]]

# Execute the test function
test_merge_python()