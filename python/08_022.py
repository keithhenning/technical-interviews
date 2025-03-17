from collections import Counter

def min_time_to_finish_tasks(tasks, n):
   """
   Calculate the minimum time required to execute all tasks
   with cooldown.
   
   Args:
       tasks: List of characters, each representing a task
       n: Integer cooldown period
       
   Returns:
       Integer representing the minimum time required
   """
   if not tasks:
      return 0
   
   # Count frequency of each task
   task_counts = Counter(tasks)
   
   # Find maximum frequency
   max_freq = max(task_counts.values())
   
   # Count how many tasks have the maximum frequency
   max_freq_tasks = sum(1 for count in task_counts.values() 
                     if count == max_freq)
   
   # Calculate the time using the formula:
   # (max_freq - 1) * (n + 1) + max_freq_tasks
   # This creates "frames" of size (n+1) with max frequency tasks
   # at start of each frame
   result = (max_freq - 1) * (n + 1) + max_freq_tasks
   
   # The result should be at least the total number of tasks
   # (in case we have many different tasks and don't need all
   # calculated idle slots)
   return max(result, len(tasks))

# Test with the example
tasks = ['A', 'A', 'B', 'C', 'A', 'B']
n = 2
print(min_time_to_finish_tasks(tasks, n))  # Output: 7

# Another test case
tasks2 = ['A', 'A', 'A', 'B', 'B', 'B']
n2 = 2
# Output: 8 (A->B->idle->A->B->idle->A->B)
print(min_time_to_finish_tasks(tasks2, n2))