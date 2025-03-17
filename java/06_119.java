import java.util.*;

public class EdmondsKarp {
   private int vertices;
   private int[][] capacity;
   private int[][] flow;
   private ArrayList<Integer>[] graph;
   
   /**
    * Initialize a flow network with given number of vertices
    */
   public EdmondsKarp(int vertices) {
      this.vertices = vertices;
      capacity = new int[vertices][vertices];
      flow = new int[vertices][vertices];
      graph = new ArrayList[vertices];
      
      for (int i = 0; i < vertices; i++) {
         graph[i] = new ArrayList<>();
      }
   }
   
   /**
    * Add edge with capacity to the flow network
    */
   public void addEdge(int u, int v, int cap) {
      // Add forward edge if not present
      if (!graph[u].contains(v)) {
         graph[u].add(v);
      }
      // Add backward edge for residual graph
      if (!graph[v].contains(u)) {
         graph[v].add(u);
      }
      // Set capacity
      capacity[u][v] = cap;
   }
   
   /**
    * Find augmenting path using BFS
    */
   private boolean bfs(int source, int sink, int[] parent) {
      boolean[] visited = new boolean[vertices];
      Arrays.fill(visited, false);
      Arrays.fill(parent, -1);
      
      Queue<Integer> queue = new LinkedList<>();
      queue.add(source);
      visited[source] = true;
      parent[source] = -1;
      
      while (!queue.isEmpty()) {
         int u = queue.poll();
         
         for (int v : graph[u]) {
            // If not visited and has residual capacity
            if (!visited[v] && capacity[u][v] > flow[u][v]) {
               queue.add(v);
               parent[v] = u;
               visited[v] = true;
            }
         }
      }
      
      // Return true if sink was reached
      return visited[sink];
   }
   
   /**
    * Compute maximum flow using Edmonds-Karp algorithm
    */
   public int findMaxFlow(int source, int sink) {
      int[] parent = new int[vertices];
      int maxFlow = 0;
      
      // Augment flow while there is a path
      while (bfs(source, sink, parent)) {
         // Find minimum residual capacity along path
         int pathFlow = Integer.MAX_VALUE;
         for (int v = sink; v != source; v = parent[v]) {
            int u = parent[v];
            pathFlow = Math.min(pathFlow, 
                  capacity[u][v] - flow[u][v]);
         }
         
         // Update flow along the path
         for (int v = sink; v != source; v = parent[v]) {
            int u = parent[v];
            flow[u][v] += pathFlow;
            flow[v][u] -= pathFlow;  // For residual graph
         }
         
         // Add path flow to total flow
         maxFlow += pathFlow;
      }
      
      return maxFlow;
   }
   
   /**
    * Print flow values for all edges
    */
   public void printFlow() {
      System.out.println("Edge \tFlow/Capacity");
      for (int i = 0; i < vertices; i++) {
         for (int j : graph[i]) {
            if (capacity[i][j] > 0) {  // Print forward edges
               System.out.println(i + " -> " + j + " \t" + 
                     flow[i][j] + "/" + capacity[i][j]);
            }
         }
      }
   }
   
   /**
    * Main method demonstrating algorithm
    */
   public static void main(String[] args) {
      // Create a flow network with 6 vertices
      EdmondsKarp graph = new EdmondsKarp(6);
      
      // Add edges with capacities
      graph.addEdge(0, 1, 16);
      graph.addEdge(0, 2, 13);
      graph.addEdge(1, 2, 10);
      graph.addEdge(1, 3, 12);
      graph.addEdge(2, 1, 4);
      graph.addEdge(2, 4, 14);
      graph.addEdge(3, 2, 9);
      graph.addEdge(3, 5, 20);
      graph.addEdge(4, 3, 7);
      graph.addEdge(4, 5, 4);
      
      int source = 0;
      int sink = 5;
      
      // Calculate maximum flow
      int maxFlow = graph.findMaxFlow(source, sink);
      
      System.out.println("Maximum flow from " + source + 
            " to " + sink + ": " + maxFlow);
      graph.printFlow();
   }
}