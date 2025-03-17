from heapq import heappush, heappop
from typing import List, Tuple, Dict, Set

def manhattan_distance(
   a: Tuple[int, int], 
   b: Tuple[int, int]
) -> int:
   """Calculate Manhattan distance between two points."""
   return abs(a[0] - b[0]) + abs(a[1] - b[1])

def get_neighbors(
   pos: Tuple[int, int], 
   grid: List[List[int]]
) -> List[Tuple[int, int]]:
   """Get valid neighboring positions."""
   neighbors = []
   for dx, dy in [
      (0, 1), (1, 0), (0, -1), (-1, 0)
   ]:  # right, down, left, up
      new_x, new_y = pos[0] + dx, pos[1] + dy
      if (0 <= new_x < len(grid) and 
          0 <= new_y < len(grid[0]) and 
          grid[new_x][new_y] != 1):
         neighbors.append((new_x, new_y))
   return neighbors

def a_star(
   grid: List[List[int]], 
   start: Tuple[int, int], 
   goal: Tuple[int, int]
) -> List[Tuple[int, int]]:
   """
   Implementation of A* pathfinding algorithm.
   Returns the path from start to goal if found, 
   empty list otherwise.
   """
   # Priority queue for open nodes
   open_set = []
   heappush(open_set, (0, start))
   
   # Dictionary to store the best previous node
   came_from: Dict[Tuple[int, int], 
                   Tuple[int, int]] = {}
   
   # Cost from start to each node
   g_score: Dict[Tuple[int, int], float] = {
      start: 0
   }
   
   # Estimated total cost from start to goal
   f_score: Dict[Tuple[int, int], float] = {
      start: manhattan_distance(start, goal)
   }
   
   # Set of visited nodes
   closed_set: Set[Tuple[int, int]] = set()
   
   while open_set:
      current = heappop(open_set)[1]
      
      if current == goal:
         # Reconstruct path
         path = []
         while current in came_from:
            path.append(current)
            current = came_from[current]
         path.append(start)
         return path[::-1]
      
      closed_set.add(current)
      
      for neighbor in get_neighbors(current, grid):
         if neighbor in closed_set:
            continue
         
         # Cost of 1 to move to adjacent square
         tentative_g_score = g_score[current] + 1
         
         if (neighbor not in g_score or 
             tentative_g_score < g_score[neighbor]):
            came_from[neighbor] = current
            g_score[neighbor] = tentative_g_score
            f_score[neighbor] = (
               g_score[neighbor] + 
               manhattan_distance(neighbor, goal)
            )
            heappush(
               open_set, 
               (f_score[neighbor], neighbor)
            )
   
   return []  # No path found

# Example usage with sample data
grid = [
   [0, 0, 0, 0, 1],
   [1, 1, 0, 1, 0],
   [0, 0, 0, 0, 0],
   [0, 1, 1, 1, 0],
   [0, 0, 0, 1, 0]
]

start = (0, 0)
goal = (4, 4)

path = a_star(grid, start, goal)
print(f"Path found: {path}")

# Visualize the path
def visualize_path(grid, path):
   visual = []
   for i in range(len(grid)):
      row = []
      for j in range(len(grid[0])):
         if (i, j) == start:
            row.append('S')
         elif (i, j) == goal:
            row.append('G')
         elif (i, j) in path:
            row.append('*')
         elif grid[i][j] == 1:
            row.append('&#x2588;')
         else:
            row.append('.')
      visual.append(' '.join(row))
   return '\n'.join(visual)

print("\nGrid visualization:")
print(visualize_path(grid, path))