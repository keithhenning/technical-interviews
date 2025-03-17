from collections import deque

def minimum_steps_to_collect_keys(maze):
  # Find the starting position and count keys
  rows, cols = len(maze), len(maze[0])
  start_row, start_col = 0, 0
  keys = []
  
  for r in range(rows):
     for c in range(cols):
        if maze[r][c] == 'S':
           start_row, start_col = r, c
        elif 'a' <= maze[r][c] <= 'z':
           keys.append(maze[r][c])
  
  # Sort keys to ensure alphabetical order
  keys.sort()
  
  # Directions for movement: up, right, down, left
  directions = [(-1, 0), (0, 1), (1, 0), (0, -1)]
  
  # Current position
  curr_row, curr_col = start_row, start_col
  total_steps = 0
  collected_keys = set()
  
  # Collect each key in alphabetical order
  for key in keys:
     # BFS to find shortest path to current key
     queue = deque([(curr_row, curr_col, 0)])  # (row, col, steps)
     visited = set([(curr_row, curr_col)])
     found = False
     
     while queue and not found:
        r, c, steps = queue.popleft()
        
        # Check if we found the key
        if maze[r][c] == key:
           total_steps += steps
           curr_row, curr_col = r, c
           collected_keys.add(key)
           found = True
           break
        
        # Try all four directions
        for dr, dc in directions:
           nr, nc = r + dr, c + dc
           
           # Check if the new position is valid
           if (0 <= nr < rows and 0 <= nc < cols and 
               maze[nr][nc] != '#' and 
               (nr, nc) not in visited):
              
              # Check if it's a door and we have the key
              if 'A' <= maze[nr][nc] <= 'Z':
                 key_needed = maze[nr][nc].lower()
                 if key_needed not in collected_keys:
                    continue
              
              queue.append((nr, nc, steps + 1))
              visited.add((nr, nc))
     
     # If we couldn't find the key, return -1
     if not found:
        return -1
  
  return total_steps