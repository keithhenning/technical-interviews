def bfs(self, start):
  # Keep track of who we've seen
  visited = set()
  # People to visit next
  queue = [start]
  # Mark start as seen
  visited.add(start)
  
  while queue:
     # Get next person to visit
     vertex = queue.pop(0)
     # Say hello!
     print(vertex, end=" ")
     
     # Check all their friends
     for neighbor in self.graph[vertex]:
        # If we haven't met them yet
        if neighbor not in visited:
           # Mark them as seen
           visited.add(neighbor)
           # Add to people to visit
           queue.append(neighbor)