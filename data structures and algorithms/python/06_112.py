def floyd_warshall(graph):
   """
   Compute all-pairs shortest paths using
   Floyd-Warshall algorithm.
   
   Finds shortest paths between every pair
   of vertices in a weighted graph.
   
   Args:
      graph (list): 2D adjacency matrix with
         edge weights
   
   Returns:
      tuple: (distances, next_vertex, get_path)
             - distances: Shortest distances
             - next_vertex: Path matrix
             - get_path: Path reconstruction
   
   Time Complexity: O(V³)
   Space Complexity: O(V²)
   """
   # Number of vertices
   n = len(graph)
   
   # Initialize distance matrix
   dist = [row[:] for row in graph]
   
   # Path reconstruction matrix
   next_vertex = [
      [
         j if graph[i][j] != float('inf') 
         and i != j else None 
         for j in range(n)
      ] for i in range(n)
   ]
   
   # Floyd-Warshall core algorithm
   for k in range(n):
      for i in range(n):
         for j in range(n):
            # Check intermediate path exists
            if (dist[i][k] != float('inf') and 
                dist[k][j] != float('inf')):
               # Update if shorter path found
               if dist[i][j] > dist[i][k] + dist[k][j]:
                  dist[i][j] = dist[i][k] + dist[k][j]
                  next_vertex[i][j] = next_vertex[i][k]
   
   def get_path(i, j):
      """
      Reconstruct shortest path between
      vertices i and j.
      
      Args:
         i (int): Source vertex
         j (int): Destination vertex
         
      Returns:
         list: Shortest path vertices
      """
      if next_vertex[i][j] is None:
         return []
      
      path = [i]
      while i != j:
         i = next_vertex[i][j]
         path.append(i)
      return path
   
   return dist, next_vertex, get_path

# Example usage
INF = float('inf')
graph = [
   [0, 5, INF, 10],
   [INF, 0, 3, INF],
   [INF, INF, 0, 1],
   [INF, INF, INF, 0]
]

# Compute shortest paths
distances, next_v, get_path = floyd_warshall(graph)

# Print distances
print("Shortest distances:")
for row in distances:
   print(row)

# Find and print path
path = get_path(0, 3)
print(f"Path from 0 to 3: {path}")