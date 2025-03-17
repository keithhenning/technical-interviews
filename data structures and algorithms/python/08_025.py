def schedule_tasks(tasks):
   # Sort tasks by priority (descending) and then by deadline
   sorted_tasks = sorted(tasks, 
                       key=lambda x: (-x['priority'], x['deadline']))
   
   # Result list to store tasks in execution order
   result = []
   
   # Timeline to track when resources are allocated
   timeline = {}  # time -> resources being used
   current_time = 0
   
   for task in sorted_tasks:
      task_id = task['id']
      resources = task['resource_needs']
      deadline = task['deadline']
      
      # Find earliest time slot where task can be executed
      execution_time = current_time
      
      # Simple implementation: schedule tasks one after another
      result.append(task_id)
      current_time += resources
   
   return result

# Test with example
tasks = [
   {"id": "T1", "priority": 3, "resource_needs": 5, 
    "deadline": 10},
   {"id": "T2", "priority": 5, "resource_needs": 3, 
    "deadline": 5},
   {"id": "T3", "priority": 2, "resource_needs": 2, 
    "deadline": 7},
   {"id": "T4", "priority": 5, "resource_needs": 1, 
    "deadline": 3}
]

print(schedule_tasks(tasks))  # Output: ["T4", "T2", "T1", "T3"]