import java.util.*;

/**
 * Graph implementation with Dijkstra's algorithm
 */
public class Graph {
   // Adjacency list representation
   private Map<String, List<Edge>> graph;
   
   /**
    * Edge representing connection between nodes
    */
   private static class Edge {
      String destination;
      int weight;
      
      public Edge(String destination, int weight) {
         this.destination = destination;
         this.weight = weight;
      }
   }
   
   /**
    * Initialize empty graph
    */
   public Graph() {
      this.graph = new HashMap<>();
   }
   
   /**
    * Add weighted edge to graph
    */
   public void addEdge(String fromNode, String toNode, 
         int weight) {
      // Check for negative weights
      if (weight < 0) {
         throw new IllegalArgumentException(
            "Negative weights not allowed in Dijkstra's");
      }
      
      // Ensure source node exists
      if (!graph.containsKey(fromNode)) {
         graph.put(fromNode, new ArrayList<>());
      }
      
      // Add the edge
      graph.get(fromNode).add(new Edge(toNode, weight));
      
      // Ensure destination node exists
      if (!graph.containsKey(toNode)) {
         graph.put(toNode, new ArrayList<>());
      }
   }
   
   /**
    * Find shortest paths using Dijkstra's algorithm
    */
   public Map.Entry<Map<String, Integer>, 
         Map<String, List<String>>> dijkstra(String start) {
      // Validate start node
      if (!graph.containsKey(start)) {
         throw new IllegalArgumentException(
            "Start node '" + start + "' not in graph");
      }
      
      // Initialize distances to infinity
      Map<String, Integer> distances = new HashMap<>();
      for (String node : graph.keySet()) {
         distances.put(node, Integer.MAX_VALUE);
      }
      distances.put(start, 0);
      
      // Priority queue for node processing
      PriorityQueue<Map.Entry<Integer, String>> pq = 
         new PriorityQueue<>(
            Comparator.comparing(Map.Entry::getKey)
         );
      pq.add(new AbstractMap.SimpleEntry<>(0, start));
      
      // Track paths to each node
      Map<String, List<String>> paths = new HashMap<>();
      List<String> startPath = new ArrayList<>();
      startPath.add(start);
      paths.put(start, startPath);
      
      // Process nodes by distance order
      while (!pq.isEmpty()) {
         // Get closest unprocessed node
         Map.Entry<Integer, String> current = pq.poll();
         int currentDistance = current.getKey();
         String currentNode = current.getValue();
         
         // Skip if we found better path already
         if (currentDistance > distances.get(currentNode)) {
            continue;
         }
         
         // Check all neighbors
         for (Edge edge : graph.get(currentNode)) {
            String neighbor = edge.destination;
            int weight = edge.weight;
            
            // Calculate total distance through current node
            int distance = currentDistance + weight;
            
            // Update if shorter path found
            if (distance < distances.get(neighbor)) {
               distances.put(neighbor, distance);
               
               // Create new path
               List<String> newPath = 
                  new ArrayList<>(paths.get(currentNode));
               newPath.add(neighbor);
               paths.put(neighbor, newPath);
               
               // Add to priority queue
               pq.add(new AbstractMap.SimpleEntry<>(
                  distance, neighbor));
            }
         }
      }
      
      return new AbstractMap.SimpleEntry<>(distances, paths);
   }
   
   /**
    * Example usage
    */
   public static void main(String[] args) {
      // Create a road network graph
      Graph g = new Graph();
      
      // Add edges (city connections with distances)
      g.addEdge("Dallas", "Chicago", 920);
      g.addEdge("Dallas", "Memphis", 410);
      g.addEdge("Chicago", "Boston", 850);
      g.addEdge("Memphis", "Atlanta", 335);
      g.addEdge("Memphis", "Chicago", 480);
      g.addEdge("Atlanta", "Miami", 610);
      g.addEdge("Atlanta", "Boston", 1070);
      g.addEdge("Boston", "Miami", 1450);
      
      // Find shortest paths from Dallas
      String startNode = "Dallas";
      Map.Entry<Map<String, Integer>, 
            Map<String, List<String>>> result = 
            g.dijkstra(startNode);
      
      Map<String, Integer> distances = result.getKey();
      Map<String, List<String>> paths = result.getValue();
      
      // Print distances
      System.out.println("Shortest distances from " + 
         startNode + ":");
      for (Map.Entry<String, Integer> entry : 
            distances.entrySet()) {
         System.out.println("  To " + entry.getKey() + 
            ": " + entry.getValue() + " miles");
      }
      
      // Print paths
      System.out.println("\nShortest paths:");
      for (Map.Entry<String, List<String>> entry : 
            paths.entrySet()) {
         String node = entry.getKey();
         List<String> path = entry.getValue();
         
         if (!node.equals(startNode)) {
            System.out.println("  To " + node + ": " + 
               String.join(" -> ", path) + 
               " (distance: " + distances.get(node) + 
               " miles)");
         }
      }
   }
}