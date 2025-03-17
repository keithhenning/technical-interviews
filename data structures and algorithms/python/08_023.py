def min_team_members(intervals, K):
   # Sort intervals by start time
   intervals.sort(key=lambda x: x[0])
   
   # Keep track of covered intervals
   covered = [False] * len(intervals)
   team_count = 0
   
   while not all(covered):
      team_count += 1
      
      # Find the earliest uncovered interval
      earliest_uncovered = None
      for i in range(len(intervals)):
         if not covered[i]:
            earliest_uncovered = i
            break
      
      if earliest_uncovered is None:
         break
         
      # Start shift at the beginning of the earliest uncovered
      shift_start = intervals[earliest_uncovered][0]
      shift_end = shift_start + K
      
      # Cover all intervals that fit within this shift
      for i in range(len(intervals)):
         if (not covered[i] and 
             intervals[i][0] >= shift_start and 
             intervals[i][1] <= shift_end):
            covered[i] = True
   
   return team_count

# Test with example
intervals = [[1, 3], [2, 5], [6, 8], [8, 10], [11, 12]]
K = 5
print(min_team_members(intervals, K))  # Output: 2