from collections import defaultdict, deque

class Graph:
   def __init__(self, vertices):
      # Initialize graph with vertices
      self.vertices = vertices
      self.graph = defaultdict(list)
      self.flow = {}
      self.capacity = defaultdict(int)

   def add_edge(self, u, v, capacity):
      # Add forward edge
      self.graph[u].append(v)
      # Add backward edge for residual graph
      self.graph[v].append(u)
      # Initialize flow to 0
      self.flow[(u, v)] = 0
      self.flow[(v, u)] = 0
      # Store capacity
      self.capacity[(u, v)] = capacity

   def bfs(self, source, sink, parent):
      # Use BFS to find augmenting path
      visited = [False] * self.vertices
      queue = deque()
      
      queue.append(source)
      visited[source] = True
      
      while queue:
         u = queue.popleft()
         
         for v in self.graph[u]:
            # If not visited and there is residual capacity
            residual_capacity = (self.capacity[(u, v)] - 
                              self.flow[(u, v)])
            if not visited[v] and residual_capacity > 0:
               queue.append(v)
               visited[v] = True
               parent[v] = u
      
      # Return True if sink is reached, otherwise False
      return visited[sink]

   def edmonds_karp(self, source, sink):
      parent = [-1] * self.vertices
      max_flow = 0
      
      # Augment flow while there is an augmenting path
      while self.bfs(source, sink, parent):
         # Find minimum residual capacity along the path
         path_flow = float("Inf")
         s = sink
         while s != source:
            path_flow = min(
               path_flow, 
               self.capacity[(parent[s], s)] - 
               self.flow[(parent[s], s)])
            s = parent[s]
         
         # Augment flow along the path
         max_flow += path_flow
         v = sink
         while v != source:
            u = parent[v]
            self.flow[(u, v)] += path_flow
            self.flow[(v, u)] -= path_flow  # Update backward edge
            v = parent[v]
      
      return max_flow

   def print_flow(self):
      print("Edge \tFlow/Capacity")
      for i in range(self.vertices):
         for j in self.graph[i]:
            # Only print forward edges
            if self.capacity[(i, j)] > 0:
               print(f"{i} -> {j} \t{self.flow[(i, j)]}/"
                    f"{self.capacity[(i, j)]}")


# Example usage
if __name__ == "__main__":
   # Create a graph with 6 vertices
   g = Graph(6)
   
   # Add edges with capacities
   g.add_edge(0, 1, 16)
   g.add_edge(0, 2, 13)
   g.add_edge(1, 2, 10)
   g.add_edge(1, 3, 12)
   g.add_edge(2, 1, 4)
   g.add_edge(2, 4, 14)
   g.add_edge(3, 2, 9)
   g.add_edge(3, 5, 20)
   g.add_edge(4, 3, 7)
   g.add_edge(4, 5, 4)
   
   source = 0
   sink = 5
   
   # Find the maximum flow
   max_flow = g.edmonds_karp(source, sink)
   
   print(f"Maximum flow from {source} to {sink}: {max_flow}")
   g.print_flow()