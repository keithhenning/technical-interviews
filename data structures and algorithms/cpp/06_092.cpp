#include <iostream>
#include <vector>
#include <queue>
#include <utility>
using namespace std;

// Structure to represent a weighted edge
struct Edge {
    int src, dest, weight;
    
    // Constructor
    Edge(int s, int d, int w) : src(s), dest(d), weight(w) {}
    
    // For priority queue ordering
    bool operator>(const Edge& other) const {
        return weight > other.weight;
    }
};

vector<Edge> primsAlgorithm(
        vector<vector<pair<int, int>>>& graph) {
    int vertices = graph.size();
    vector<bool> inMST(vertices, false);
    vector<Edge> mst;
    
    // Priority queue to get minimum weight edge
    priority_queue<Edge, vector<Edge>, greater<Edge>> pq;
    
    // Start with vertex 0
    int startVertex = 0;
    inMST[startVertex] = true;
    
    // Add all edges from startVertex to the priority queue
    for (auto& neighbor : graph[startVertex]) {
        int dest = neighbor.first;
        int weight = neighbor.second;
        pq.push(Edge(startVertex, dest, weight));
    }
    
    // Keep adding edges until we have V-1 edges
    while (!pq.empty() && mst.size() < vertices - 1) {
        // Get the minimum weight edge
        Edge minEdge = pq.top();
        pq.pop();
        
        int u = minEdge.src;
        int v = minEdge.dest;
        
        // If adding this edge doesn't create a cycle
        if (!inMST[v]) {
            // Add to MST
            mst.push_back(minEdge);
            inMST[v] = true;
            
            // Add all edges from the newly added vertex
            for (auto& neighbor : graph[v]) {
                int newDest = neighbor.first;
                int weight = neighbor.second;
                
                // Only if destination is not already in MST
                if (!inMST[newDest]) {
                    pq.push(Edge(v, newDest, weight));
                }
            }
        }
    }
    
    return mst;
}

int main() {
    // Example graph with 4 vertices
    int vertices = 4;
    vector<vector<pair<int, int>>> graph(vertices);
    
    // Add edges to the graph (both directions)
    // A(0) - B(1) with weight 2
    graph[0].push_back({1, 2});
    graph[1].push_back({0, 2});
    
    // A(0) - D(3) with weight 1
    graph[0].push_back({3, 1});
    graph[3].push_back({0, 1});
    
    // B(1) - D(3) with weight 2
    graph[1].push_back({3, 2});
    graph[3].push_back({1, 2});
    
    // B(1) - C(2) with weight 3
    graph[1].push_back({2, 3});
    graph[2].push_back({1, 3});
    
    // C(2) - D(3) with weight 4
    graph[2].push_back({3, 4});
    graph[3].push_back({2, 4});
    
    vector<Edge> mst = primsAlgorithm(graph);
    
    cout << "Minimum Spanning Tree edges:" << endl;
    for (const Edge& edge : mst) {
        cout << edge.src << " -- " << edge.dest << " : " 
             << edge.weight << endl;
    }
    
    return 0;
}