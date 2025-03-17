class Graph:
  def __init__(self):
     # Initialize empty graph
     self.graph = {}
  
  def add_vertex(self, vertex):
     # Add vertex if not exists
     if vertex not in self.graph:
        self.graph[vertex] = []
  
  def add_edge(self, v1, v2):
     # Add vertices if not exists
     if v1 not in self.graph:
        self.add_vertex(v1)
     if v2 not in self.graph:
        self.add_vertex(v2)
     # Create directional edge
     self.graph[v1].append(v2)
      
  def remove_node(self, node):
     # Skip if node not in graph
     if node not in self.graph:
        return
     # Remove node references
     for friend in self.graph[node]:
        self.graph[friend].remove(node)
     # Delete node
     del self.graph[node]
  
  def bfs(self, start):
     # Breadth-first search
     visited = set()
     queue = [start]
     visited.add(start)
      
     while queue:
        node = queue.pop(0)
        print(node, end=" ")
         
        for friend in self.graph[node]:
           if friend not in visited:
              visited.add(friend)
              queue.append(friend)

# Test code                    
social_graph = Graph()
social_graph.add_edge("Alice", "Bob")
social_graph.add_edge("Alice", "Charlie") 
social_graph.add_edge("Bob", "David")
social_graph.bfs("Alice")