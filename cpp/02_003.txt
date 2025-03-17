function mergeIntervals(intervals):
  if intervals is empty:
    return empty array
    
  sort intervals by start time
  initialize result array with first interval
  
  for each current interval in intervals (starting from second):
    last interval = last interval in result array
    
    if current interval's start <= last interval's end:
      merge by updating last interval's end to max(last interval's end, current interval's end)
    else:
      add current interval to result
      
  return result