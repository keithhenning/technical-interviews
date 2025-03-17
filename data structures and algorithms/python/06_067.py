from collections import defaultdict, deque

class Graph:
   """
   A graph implementation with topological sorting.
   
   Implements directed graph with two topological sorting
   algorithms: Kahn's (BFS) and DFS-based approach.
   
   Attributes:
      graph (defaultdict): Adjacency list of the graph
      V (int): Number of vertices in the graph
      
   Note:
      - Graph must be a DAG for topological sort
      - Vertices are integers from 0 to V-1
   """
   
   def __init__(self, vertices):
      """
      Initialize graph with vertices.
      
      Args:
         vertices (int): Number of vertices
      """
      self.graph = defaultdict(list)
      self.V = vertices
   
   def add_edge(self, u, v):
      """
      Add directed edge from u to v.
      
      Args:
         u (int): Source vertex
         v (int): Destination vertex
      """
      self.graph[u].append(v)
   
   def topological_sort_kahn(self):
      """
      Perform topological sort using Kahn's algorithm.
      
      Returns:
         list: Sorted vertices or empty list if cycle exists
      """
      # Calculate in-degree of all vertices
      in_degree = [0] * self.V
      for i in self.graph:
         for j in self.graph[i]:
            in_degree[j] += 1
      
      # Add vertices with 0 in-degree to queue
      queue = deque()
      for i in range(self.V):
         if in_degree[i] == 0:
            queue.append(i)
      
      result = []
      while queue:
         vertex = queue.popleft()
         result.append(vertex)
         
         # Reduce in-degree of adjacent vertices
         for neighbor in self.graph[vertex]:
            in_degree[neighbor] -= 1
            if in_degree[neighbor] == 0:
               queue.append(neighbor)
      
      # Check for cycle
      return result if len(result) == self.V else []
   
   def topological_sort_dfs(self):
      """
      Perform topological sort using DFS algorithm.
      
      Returns:
         list: Topologically sorted list of vertices
      """
      visited = [False] * self.V
      stack = []
      
      def dfs(v):
         """
         Helper function for DFS traversal.
         
         Args:
            v (int): Current vertex
         """
         visited[v] = True
         for neighbor in self.graph[v]:
            if not visited[neighbor]:
               dfs(neighbor)
         stack.insert(0, v)
      
      # Run DFS on all unvisited vertices
      for vertex in range(self.V):
         if not visited[vertex]:
            dfs(vertex)
            
      return stack