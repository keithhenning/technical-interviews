#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

// Structure to represent an edge
struct Edge {
    int src, dest, weight;
    
    // Constructor
    Edge(int src, int dest, int weight) : 
        src(src), dest(dest), weight(weight) {}
    
    // Comparison operator for sorting
    bool operator<(const Edge& other) const {
        return weight < other.weight;
    }
};

// DisjointSet class (Union-Find)
class DisjointSet {
private:
    vector<int> parent, rank;
    
public:
    // Constructor
    DisjointSet(int n) {
        parent.resize(n);
        rank.resize(n, 0);
        
        // Initialize each element as a separate set
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }
    
    // Find with path compression
    int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }
    
    // Union by rank
    bool unionSets(int x, int y) {
        int rootX = find(x);
        int rootY = find(y);
        
        if (rootX == rootY) {
            return false;
        }
        
        if (rank[rootX] < rank[rootY]) {
            parent[rootX] = rootY;
        } else if (rank[rootX] > rank[rootY]) {
            parent[rootY] = rootX;
        } else {
            parent[rootY] = rootX;
            rank[rootX]++;
        }
        
        return true;
    }
};

// Function to find MST using Kruskal's algorithm
vector<Edge> kruskal(vector<Edge>& edges, int vertices) {
    // Sort edges by weight
    sort(edges.begin(), edges.end());
    
    // Initialize disjoint set
    DisjointSet ds(vertices);
    
    vector<Edge> mst;
    int mstWeight = 0;
    
    // Process edges in order of increasing weight
    for (Edge edge : edges) {
        // If including this edge doesn't create a cycle
        if (ds.unionSets(edge.src, edge.dest)) {
            mst.push_back(edge);
            mstWeight += edge.weight;
            
            // Stop when we have V-1 edges
            if (mst.size() == vertices - 1) {
                break;
            }
        }
    }
    
    cout << "Total MST weight: " << mstWeight << endl;
    return mst;
}

int main() {
    int vertices = 6;
    vector<Edge> edges;
    
    // Add edges: (src, dest, weight)
    edges.push_back(Edge(0, 1, 4));
    edges.push_back(Edge(0, 2, 3));
    edges.push_back(Edge(1, 2, 1));
    edges.push_back(Edge(1, 3, 2));
    edges.push_back(Edge(2, 3, 4));
    edges.push_back(Edge(2, 4, 3));
    edges.push_back(Edge(3, 4, 2));
    edges.push_back(Edge(3, 5, 1));
    edges.push_back(Edge(4, 5, 3));
    
    vector<Edge> mst = kruskal(edges, vertices);
    
    cout << "Edges in the MST:" << endl;
    for (Edge edge : mst) {
        cout << edge.src << " -- " << edge.dest << " == " << edge.weight << endl;
    }
    
    return 0;
}