#include <iostream>
#include <vector>
#include <limits>
#include <algorithm>

// Avoid overflow when adding large values
const int INF = std::numeric_limits<int>::max() / 2;

// Structure to hold algorithm results
struct FloydWarshallResult {
   std::vector<std::vector<int>> distances;
   std::vector<std::vector<int>> nextVertex;
};

// Floyd-Warshall all-pairs shortest path algorithm
FloydWarshallResult floydWarshall(
      const std::vector<std::vector<int>>& graph) {
   int n = graph.size();
   std::vector<std::vector<int>> dist = graph;
   std::vector<std::vector<int>> next(n, 
                                    std::vector<int>(n, -1));
   
   // Initialize next matrix for path reconstruction
   for (int i = 0; i < n; i++) {
      for (int j = 0; j < n; j++) {
         if (graph[i][j] != INF && i != j) {
            next[i][j] = j;
         }
      }
   }
   
   // Floyd-Warshall algorithm
   for (int k = 0; k < n; k++) {
      for (int i = 0; i < n; i++) {
         for (int j = 0; j < n; j++) {
            if (dist[i][k] != INF && dist[k][j] != INF) {
               if (dist[i][j] > dist[i][k] + dist[k][j]) {
                  dist[i][j] = dist[i][k] + dist[k][j];
                  next[i][j] = next[i][k];
               }
            }
         }
      }
   }
   
   return {dist, next};
}

// Reconstruct path from start to end using next matrix
std::vector<int> getPath(int start, int end, 
                        const std::vector<std::vector<int>>& 
                           next) {
   std::vector<int> path;
   if (next[start][end] == -1) {
      return path;  // No path exists
   }
   
   path.push_back(start);
   while (start != end) {
      start = next[start][end];
      path.push_back(start);
   }
   
   return path;
}

int main() {
   // Example graph represented as adjacency matrix
   std::vector<std::vector<int>> graph = {
      {0, 5, INF, 10},
      {INF, 0, 3, INF},
      {INF, INF, 0, 1},
      {INF, INF, INF, 0}
   };
   
   FloydWarshallResult result = floydWarshall(graph);
   
   // Print shortest distances
   std::cout << "Shortest distances between all pairs:"
             << std::endl;
   for (const auto& row : result.distances) {
      for (int val : row) {
         if (val == INF) {
            std::cout << "INF ";
         } else {
            std::cout << val << " ";
         }
      }
      std::cout << std::endl;
   }
   
   // Find path from vertex 0 to vertex 3
   std::vector<int> path = getPath(0, 3, 
                                 result.nextVertex);
   if (!path.empty()) {
      std::cout << "Path from 0 to 3: ";
      for (int vertex : path) {
         std::cout << vertex << " ";
      }
      std::cout << std::endl;
   } else {
      std::cout << "No path exists from 0 to 3" 
                << std::endl;
   }
   
   return 0;
}