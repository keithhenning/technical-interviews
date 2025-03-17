def astar(grid, start, goal):
   """
   Find the shortest path between start and goal positions 
   using the A* pathfinding algorithm.
   """
   # Calculate distance using Manhattan distance heuristic
   def heuristic(a, b):
      return abs(a[0] - b[0]) + abs(a[1] - b[1])
   
   # Euclidean distance heuristic
   def euclidean_heuristic(a, b):
      return ((a[0] - b[0])**2 + 
              (a[1] - b[1])**2)**0.5
   
   # Get valid neighboring cells
   def get_neighbors(pos):
      x, y = pos
      # Check right, left, down, up
      neighbors = [
         (x+1, y), (x-1, y), 
         (x, y+1), (x, y-1)
      ]
      # Return only valid and walkable neighbors
      return [
         (x, y) for (x, y) in neighbors 
         if 0 <= x < len(grid) and 
            0 <= y < len(grid[0]) and 
            grid[x][y] != 1
      ]
   
   # Initialize sets and tracking
   open_set = {start}
   closed_set = set()
   came_from = {}
   g_score = {start: 0}
   f_score = {start: heuristic(start, goal)}
   
   while open_set:
      # Find position with lowest f_score
      current = min(
         open_set, 
         key=lambda pos: f_score.get(pos, float('inf'))
      )
      
      if current == goal:
         # Reconstruct the path
         path = []
         while current in came_from:
            path.append(current)
            current = came_from[current]
         path.append(start)
         return path[::-1]
      
      open_set.remove(current)
      closed_set.add(current)
      
      # Check each neighbor
      for neighbor in get_neighbors(current):
         if neighbor in closed_set:
            continue
         
         # Calculate tentative cost
         tentative_g_score = g_score[current] + 1
         
         if neighbor not in open_set:
            open_set.add(neighbor)
         elif tentative_g_score >= g_score.get(
               neighbor, float('inf')
            ):
            continue
         
         # Best path so far
         came_from[neighbor] = current
         g_score[neighbor] = tentative_g_score
         f_score[neighbor] = (
            g_score[neighbor] + 
            heuristic(neighbor, goal)
         )
   
   return []  # No path found

# Visualize path in grid
def print_path(grid, path):
   for i in range(len(grid)):
      for j in range(len(grid[0])):
         if (i, j) == path[0]:
            print('S', end=' ')  # Start
         elif (i, j) == path[-1]:
            print('G', end=' ')  # Goal
         elif (i, j) in path:
            print('*', end=' ')  # Path
         elif grid[i][j] == 1:
            print('&#x2588;', end=' ')  # Wall
         else:
            print('.', end=' ')  # Empty space
      print()

# Test the algorithm
if __name__ == "__main__":
   grid = [
      [0, 0, 0, 0, 0],
      [1, 1, 0, 1, 0],
      [0, 0, 0, 0, 0],
      [0, 1, 1, 0, 0],
      [0, 0, 0, 0, 0]
   ]

   start = (0, 0)
   goal = (4, 4)

   path = astar(grid, start, goal)
   print("Found path:", path)
   print("\nGrid visualization:")
   print_path(grid, path)