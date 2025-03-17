import java.util.*;

public class PrimsAlgorithm {
   /**
    * Edge in a weighted graph
    */
   static class Edge implements Comparable<Edge> {
      int source;
      int destination;
      int weight;
      
      public Edge(int source, int destination, int weight) {
         this.source = source;
         this.destination = destination;
         this.weight = weight;
      }
      
      @Override
      public int compareTo(Edge other) {
         return this.weight - other.weight;
      }
   }
   
   /**
    * Find Minimum Spanning Tree using Prim's algorithm
    */
   public static List<Edge> primsAlgorithm(
         List<List<Edge>> graph) {
      int vertices = graph.size();
      boolean[] inMST = new boolean[vertices];
      List<Edge> mst = new ArrayList<>();
      
      // Priority queue for edges by weight
      PriorityQueue<Edge> pq = new PriorityQueue<>();
      
      // Start with vertex 0
      int startVertex = 0;
      inMST[startVertex] = true;
      
      // Add all edges from start vertex
      for (Edge edge : graph.get(startVertex)) {
         pq.add(edge);
      }
      
      // Build MST with V-1 edges
      while (!pq.isEmpty() && mst.size() < vertices - 1) {
         // Get minimum weight edge
         Edge minEdge = pq.poll();
         
         // Check if destination already in MST
         if (!inMST[minEdge.destination]) {
            // Add to MST
            mst.add(minEdge);
            int newVertex = minEdge.destination;
            inMST[newVertex] = true;
            
            // Add edges from newly added vertex
            for (Edge edge : graph.get(newVertex)) {
               // Only if not creating cycle
               if (!inMST[edge.destination]) {
                  pq.add(edge);
               }
            }
         }
      }
      
      return mst;
   }
   
   /**
    * Test Prim's algorithm
    */
   public static void main(String[] args) {
      // Create graph with 4 vertices
      int vertices = 4;
      List<List<Edge>> graph = new ArrayList<>(vertices);
      
      for (int i = 0; i < vertices; i++) {
         graph.add(new ArrayList<>());
      }
      
      // Add edges (undirected graph)
      // A(0) - B(1) weight 2
      graph.get(0).add(new Edge(0, 1, 2));
      graph.get(1).add(new Edge(1, 0, 2));
      
      // A(0) - D(3) weight 1
      graph.get(0).add(new Edge(0, 3, 1));
      graph.get(3).add(new Edge(3, 0, 1));
      
      // B(1) - D(3) weight 2
      graph.get(1).add(new Edge(1, 3, 2));
      graph.get(3).add(new Edge(3, 1, 2));
      
      // B(1) - C(2) weight 3
      graph.get(1).add(new Edge(1, 2, 3));
      graph.get(2).add(new Edge(2, 1, 3));
      
      // C(2) - D(3) weight 4
      graph.get(2).add(new Edge(2, 3, 4));
      graph.get(3).add(new Edge(3, 2, 4));
      
      // Run Prim's algorithm
      List<Edge> mst = primsAlgorithm(graph);
      
      // Print result
      System.out.println("Minimum Spanning Tree edges:");
      for (Edge edge : mst) {
         System.out.println(edge.source + " -- " + 
            edge.destination + " : " + edge.weight);
      }
   }
}