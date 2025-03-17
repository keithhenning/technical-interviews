from collections import defaultdict, deque

def resolve_dependencies(tasks):
   graph = defaultdict(list)
   in_degree = {task: 0 for task in tasks}
   
   for task, dependencies in tasks.items():
      for dep in dependencies:
         graph[dep].append(task)
         in_degree[task] += 1
   
   queue = deque([task for task, degree in in_degree.items() 
                if degree == 0])
   result = []
   
   while queue:
      current = queue.popleft()
      result.append(current)
      
      for dependent in graph[current]:
         in_degree[dependent] -= 1
         if in_degree[dependent] == 0:
            queue.append(dependent)
   
   if len(result) != len(tasks):
      return None
   
   return result