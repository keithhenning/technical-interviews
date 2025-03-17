import java.util.Arrays;
import java.util.ArrayList;
import java.util.List;

public class FloydWarshall {
   // Avoid overflow when adding distances
   private static final int INF = Integer.MAX_VALUE / 2;
   
   /**
    * Main method to demonstrate the algorithm
    */
   public static void main(String[] args) {
      // Example graph represented as adjacency matrix
      int[][] graph = {
         {0, 5, INF, 10},
         {INF, 0, 3, INF},
         {INF, INF, 0, 1},
         {INF, INF, INF, 0}
      };
      
      // Run Floyd-Warshall algorithm
      FloydWarshallResult result = floydWarshall(graph);
      
      // Print all-pairs shortest paths
      System.out.println("Shortest distances:");
      for (int[] row : result.distances) {
         System.out.println(Arrays.toString(row));
      }
      
      // Find path from vertex 0 to 3
      List<Integer> path = getPath(0, 3, result.nextVertex);
      if (!path.isEmpty()) {
         System.out.println("Path from 0 to 3: " + path);
      } else {
         System.out.println("No path exists from 0 to 3");
      }
   }
   
   /**
    * Result container for the algorithm
    */
   static class FloydWarshallResult {
      int[][] distances;
      Integer[][] nextVertex;
      
      FloydWarshallResult(int[][] distances, 
            Integer[][] nextVertex) {
         this.distances = distances;
         this.nextVertex = nextVertex;
      }
   }
   
   /**
    * Floyd-Warshall all-pairs shortest path algorithm
    */
   public static FloydWarshallResult floydWarshall(
         int[][] graph) {
      int n = graph.length;
      int[][] dist = new int[n][n];
      Integer[][] next = new Integer[n][n];
      
      // Initialize distance and next matrices
      for (int i = 0; i < n; i++) {
         for (int j = 0; j < n; j++) {
            dist[i][j] = graph[i][j];
            if (graph[i][j] != INF && i != j) {
               next[i][j] = j;
            }
         }
      }
      
      // Main algorithm - consider all vertices as intermediates
      for (int k = 0; k < n; k++) {
         for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
               if (dist[i][k] != INF && dist[k][j] != INF) {
                  // If path through k is shorter
                  if (dist[i][j] > dist[i][k] + dist[k][j]) {
                     dist[i][j] = dist[i][k] + dist[k][j];
                     next[i][j] = next[i][k];
                  }
               }
            }
         }
      }
      
      return new FloydWarshallResult(dist, next);
   }
   
   /**
    * Reconstruct path from start to end using next matrix
    */
   public static List<Integer> getPath(int start, int end,
         Integer[][] next) {
      List<Integer> path = new ArrayList<>();
      
      // No path exists
      if (next[start][end] == null) {
         return path;
      }
      
      // Reconstruct path
      path.add(start);
      while (start != end) {
         start = next[start][end];
         path.add(start);
      }
      
      return path;
   }
}