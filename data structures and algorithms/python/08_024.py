from collections import deque

def flood_fill_time(maze, startX, startY, targetX, targetY):
   rows, cols = len(maze), len(maze[0])
   visited = [[False for _ in range(cols)] for _ in range(rows)]
   
   # BFS queue with (x, y, time)
   queue = deque([(startX, startY, 0)])
   visited[startX][startY] = True
   
   directions = [(1, 0), (-1, 0), (0, 1), (0, -1)]
   
   while queue:
      x, y, time = queue.popleft()
      
      # If water reaches target
      if x == targetX and y == targetY:
         return time
      
      for dx, dy in directions:
         nx, ny = x + dx, y + dy
         
         # Check if new position is valid
         if (0 <= nx < rows and 0 <= ny < cols and 
             not visited[nx][ny] and maze[nx][ny] == 0):
            visited[nx][ny] = True
            queue.append((nx, ny, time + 1))
   
   return -1

# Test example
maze = [
   [0, 0, 0, 0],
   [1, 1, 0, 1],
   [0, 2, 0, 0],
   [0, 1, 1, 0]
]
print(flood_fill_time(maze, 2, 1, 0, 0))  # Output: 3