#include <iostream>
#include <vector>
#include <queue>
#include <limits>
#include <algorithm>

// Max flow graph using Edmonds-Karp algorithm
class Graph {
private:
   int vertices;
   // Adjacency, capacity, and flow matrices
   std::vector<std::vector<int>> capacity;
   std::vector<std::vector<int>> flow;
   std::vector<std::vector<int>> adj;
   
   // BFS to find augmenting path
   bool bfs(int source, int sink, 
            std::vector<int>& parent) {
      // Track visited vertices
      std::vector<bool> visited(vertices, false);
      std::queue<int> q;
      
      // Start BFS from source
      q.push(source);
      visited[source] = true;
      parent[source] = -1;
      
      while (!q.empty()) {
         int u = q.front();
         q.pop();
         
         // Check adjacent vertices
         for (int v : adj[u]) {
            // Find path with residual capacity
            if (!visited[v] && 
                capacity[u][v] > flow[u][v]) {
               q.push(v);
               parent[v] = u;
               visited[v] = true;
            }
         }
      }
      
      // Return if sink is reachable
      return visited[sink];
   }

public:
   // Constructor initializes graph
   Graph(int v) : vertices(v) {
      adj.resize(vertices);
      capacity.resize(vertices, 
         std::vector<int>(vertices, 0));
      flow.resize(vertices, 
         std::vector<int>(vertices, 0));
   }
   
   // Add directed edge with capacity
   void addEdge(int u, int v, int cap) {
      // Add forward and backward edges
      adj[u].push_back(v);
      adj[v].push_back(u);
      capacity[u][v] = cap;
   }
   
   // Edmonds-Karp max flow algorithm
   int edmondsKarp(int source, int sink) {
      int maxFlow = 0;
      std::vector<int> parent(vertices);
      
      // Find augmenting paths
      while (bfs(source, sink, parent)) {
         // Find min residual capacity
         int pathFlow = std::numeric_limits<int>::max();
         for (int v = sink; v != source; v = parent[v]) {
            int u = parent[v];
            pathFlow = std::min(
               pathFlow, 
               capacity[u][v] - flow[u][v]
            );
         }
         
         // Update flow along path
         for (int v = sink; v != source; v = parent[v]) {
            int u = parent[v];
            flow[u][v] += pathFlow;
            flow[v][u] -= pathFlow;
         }
         
         // Accumulate max flow
         maxFlow += pathFlow;
      }
      
      return maxFlow;
   }
   
   // Print flow details
   void printFlow() {
      std::cout << "Edge \tFlow/Capacity" << std::endl;
      for (int u = 0; u < vertices; u++) {
         for (int v : adj[u]) {
            // Print only forward edges
            if (capacity[u][v] > 0) {
               std::cout << u << " -> " << v 
                         << " \t" << flow[u][v] 
                         << "/" << capacity[u][v] 
                         << std::endl;
            }
         }
      }
   }
};

int main() {
   // Create graph with 6 vertices
   Graph g(6);
   
   // Add edges with capacities
   g.addEdge(0, 1, 16);
   g.addEdge(0, 2, 13);
   g.addEdge(1, 2, 10);
   g.addEdge(1, 3, 12);
   g.addEdge(2, 1, 4);
   g.addEdge(2, 4, 14);
   g.addEdge(3, 2, 9);
   g.addEdge(3, 5, 20);
   g.addEdge(4, 3, 7);
   g.addEdge(4, 5, 4);
   
   // Define source and sink
   int source = 0;
   int sink = 5;
   
   // Calculate max flow
   int maxFlow = g.edmondsKarp(source, sink);
   
   // Output results
   std::cout << "Maximum flow from " << source 
             << " to " << sink << ": " 
             << maxFlow << std::endl;
   g.printFlow();
   
   return 0;
}