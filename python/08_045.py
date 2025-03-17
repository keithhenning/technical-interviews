def min_processing_power(tasks, max_seconds):
  def can_complete(power):
     total_time = 0
     for task in tasks:
        # Ceiling division
        total_time += (task + power - 1) // power
     return total_time <= max_seconds
  
  left, right = 1, max(tasks)
  
  while left < right:
     mid = (left + right) // 2
     if can_complete(mid):
        right = mid
     else:
        left = mid + 1
        
  return left