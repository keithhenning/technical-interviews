class DisjointSet:
   """
   Disjoint-Set (Union-Find) data structure
   implementation.
   
   Efficiently tracks disjoint sets with path
   compression and union by rank optimizations
   for near-constant time operations.
   
   Attributes:
      parent (list): Parent pointers for each
         element
      rank (list): Rank of each set to optimize
         union operations
   """
   def __init__(self, n):
      # Initialize parent and rank lists
      self.parent = list(range(n))
      self.rank = [0] * n
   
   def find(self, x):
      """
      Find the representative of the set
      containing element x.
      
      Args:
         x (int): Element to find
         
      Returns:
         int: Representative of x's set
         
      Time Complexity: O(&#x3b1;(n)) amortized
      """
      if self.parent[x] != x:
         # Path compression
         self.parent[x] = self.find(
            self.parent[x]
         )
      return self.parent[x]
   
   def union(self, x, y):
      """
      Merge the sets containing elements x
      and y.
      
      Args:
         x (int): First element
         y (int): Second element
         
      Returns:
         bool: True if x and y were in
            different sets (union performed),
            False if they were already in
            the same set
            
      Time Complexity: O(&#x3b1;(n)) amortized
      """
      # Find roots of x and y
      root_x = self.find(x)
      root_y = self.find(y)
      
      # Check if already in same set
      if root_x == root_y:
         return False
      
      # Union by rank
      if self.rank[root_x] < self.rank[root_y]:
         self.parent[root_x] = root_y
      elif self.rank[root_x] > self.rank[root_y]:
         self.parent[root_y] = root_x
      else:
         # Ranks are equal, arbitrarily choose
         # one as root
         self.parent[root_y] = root_x
         self.rank[root_x] += 1
      
      return True


def kruskal(graph, vertices):
   """
   Find minimum spanning tree using
   Kruskal's algorithm.
   
   Builds a minimum spanning tree by
   adding edges in order of increasing
   weight, skipping edges that would
   create cycles.
   
   Args:
      graph (list): Adjacency list of the
         form [[(v, weight),...],...]
         where graph[u] contains edges
         from u
      vertices (int): Number of vertices
         in the graph
   
   Returns:
      tuple: (mst, total_weight) where:
         - mst is list of (u, v, weight)
           tuples representing MST edges
         - total_weight is the sum of all
           edge weights in the MST
   
   Time Complexity: O(E log E)
   Space Complexity: O(V + E)
   """
   # Create a list of all edges
   edges = []
   for u in range(vertices):
      for v, weight in graph[u]:
         # Add each edge only once
         if u < v:
            edges.append((weight, u, v))
   
   # Sort edges by weight
   edges.sort()
   
   # Initialize disjoint set
   ds = DisjointSet(vertices)
   
   mst = []
   mst_weight = 0
   
   # Process edges in order of increasing
   # weight
   for weight, u, v in edges:
      # If including this edge doesn't
      # create a cycle
      if ds.union(u, v):
         mst.append((u, v, weight))
         mst_weight += weight
         
         # Stop when we have V-1 edges
         if len(mst) == vertices - 1:
            break
   
   return mst, mst_weight


# Example usage
if __name__ == "__main__":
   # Example graph: adjacency list with
   # (neighbor, weight) pairs
   vertices = 6
   graph = [[] for _ in range(vertices)]
   
   # Add edges: (u, v, weight)
   edges = [
      (0, 1, 4), (0, 2, 3), (1, 2, 1),
      (1, 3, 2), (2, 3, 4), (2, 4, 3),
      (3, 4, 2), (3, 5, 1), (4, 5, 3)
   ]
   
   for u, v, w in edges:
      # Undirected graph
      graph[u].append((v, w))
      graph[v].append((u, w))
   
   mst, total_weight = kruskal(graph, vertices)
   
   print("Edges in the MST:")
   for u, v, w in mst:
      print(f"{u} -- {v} == {w}")
   print(f"Total MST weight: {total_weight}")