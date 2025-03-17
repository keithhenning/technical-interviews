import heapq

def prims_algorithm(graph):
  """
  Find minimum spanning tree using Prim's algorithm.
  
  Builds a minimum spanning tree (MST) by greedily selecting 
  the lowest-weight edge that connects a vertex in the MST 
  to a vertex outside the MST.
  
  Args:
     graph: Dictionary representing an adjacency list with weights
            {node: [(neighbor, weight), ...], ...}
  
  Returns:
     List of tuples (u, v, weight) representing edges in the MST
     
  Time Complexity: 
     O(E log V) where E is the number of edges and V is 
     the number of vertices
     
  Space Complexity:
     O(E + V) for storing the priority queue and tracking 
     vertices
     
  Example:
     >>> graph = {
     ...    'A': [('B', 2), ('C', 3)],
     ...    'B': [('A', 2), ('C', 1), ('D', 1)],
     ...    'C': [('A', 3), ('B', 1), ('D', 2)],
     ...    'D': [('B', 1), ('C', 2)]
     ... }
     >>> prims_algorithm(graph)
     [('A', 'B', 2), ('B', 'C', 1), ('B', 'D', 1)]
  """
  # Start with first vertex
  start_vertex = list(graph.keys())[0]
  
  # Track MST vertices and edges
  mst_vertices = {start_vertex}
  mst_edges = []
  
  # Priority queue of edges
  edges = [(weight, start_vertex, neighbor) 
           for neighbor, weight in graph[start_vertex]]
  heapq.heapify(edges)
  
  # Process edges while not all vertices included
  while edges and len(mst_vertices) < len(graph):
     weight, u, v = heapq.heappop(edges)
     
     # Add edge if it connects new vertex
     if v not in mst_vertices:
        mst_vertices.add(v)
        mst_edges.append((u, v, weight))
        
        # Add new candidate edges
        for neighbor, w in graph[v]:
           if neighbor not in mst_vertices:
              heapq.heappush(edges, (w, v, neighbor))
  
  return mst_edges

# Example usage
if __name__ == "__main__":
  graph = {
     'A': [('B', 2), ('D', 1)],
     'B': [('A', 2), ('D', 2), ('C', 3)],
     'C': [('B', 3), ('D', 4)],
     'D': [('A', 1), ('B', 2), ('C', 4)]
  }
  
  mst = prims_algorithm(graph)
  print("Minimum Spanning Tree edges:")
  for u, v, weight in mst:
     print(f"{u} -- {v} : {weight}")