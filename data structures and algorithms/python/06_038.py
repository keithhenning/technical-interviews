from collections import defaultdict
import heapq

class Graph:
   """
   A graph implementation with Dijkstra's shortest 
   path algorithm.
   
   Represents a weighted directed graph using an 
   adjacency list with Dijkstra's algorithm for 
   finding shortest paths.
   """
   
   def __init__(self):
      """Initialize an empty graph."""
      self.graph = defaultdict(list)
   
   def add_edge(self, from_node, to_node, weight):
      """
      Add a weighted edge to the graph.
      
      Args:
         from_node: The source node
         to_node: The destination node
         weight (numeric): The edge weight/distance
         
      Raises:
         ValueError: If weight is negative
      """
      if weight < 0:
         raise ValueError(
            "Negative weights are not allowed"
         )
      
      self.graph[from_node].append(
         (to_node, weight)
      )
      
      # Ensure to_node exists in the graph
      if to_node not in self.graph:
         self.graph[to_node] = []
   
   def dijkstra(self, start):
      """
      Find shortest paths from start node using 
      Dijkstra's algorithm.
      
      Args:
         start: The starting node
         
      Returns:
         tuple: (distances, paths) where:
            - distances: Shortest distances 
            - paths: Shortest paths
      """
      if start not in self.graph:
         raise KeyError(
            f"Start node '{start}' not in graph"
         )
      
      # Initialize distances to infinity
      distances = {
         node: float('infinity') 
         for node in self.graph
      }
      distances[start] = 0
      
      # Priority queue to store (distance, node)
      pq = [(0, start)]
      
      # Track shortest paths
      paths = {start: [start]}
      
      while pq:
         current_distance, current_node = (
            heapq.heappop(pq)
         )
         
         # Skip if longer path found
         if current_distance > distances[current_node]:
            continue
         
         # Check all neighbors
         for neighbor, weight in (
            self.graph[current_node]
         ):
            distance = current_distance + weight
            
            # Update if shorter path found
            if distance < distances[neighbor]:
               distances[neighbor] = distance
               paths[neighbor] = (
                  paths[current_node] + [neighbor]
               )
               heapq.heappush(
                  pq, (distance, neighbor)
               )
         
      return distances, paths

# Example usage
if __name__ == "__main__":
   # Create graph representing US city network
   g = Graph()
   
   # Add edges (from_city, to_city, distance)
   g.add_edge('Dallas', 'Chicago', 920)
   g.add_edge('Dallas', 'Memphis', 410)
   g.add_edge('Chicago', 'Boston', 850)
   g.add_edge('Memphis', 'Atlanta', 335)
   g.add_edge('Memphis', 'Chicago', 480)
   g.add_edge('Atlanta', 'Miami', 610)
   g.add_edge('Atlanta', 'Boston', 1070)
   g.add_edge('Boston', 'Miami', 1450)
   
   # Run Dijkstra's algorithm from Dallas
   start_node = 'Dallas'
   distances, paths = g.dijkstra(start_node)
   
   # Print results
   print(f"Shortest distances from {start_node}:")
   for node, distance in distances.items():
      print(f"  To {node}: {distance} miles")
   
   print("\nShortest paths:")
   for node, path in paths.items():
      if node != start_node:
         print(
            f"  To {node}: {' -> '.join(path)} "
            f"(distance: {distances[node]} miles)"
         )