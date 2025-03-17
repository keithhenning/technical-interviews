#include <iostream>
#include <unordered_map>
#include <vector>
#include <queue>
#include <unordered_set>

class Graph {
private:
    std::unordered_map<int, 
        std::vector<int>> graph;

public:
    Graph() {}
    
    void addVertex(int vertex) {
        // In C++, if the key doesn't exist, it's 
        // automatically created with an empty vector 
        if (graph.find(vertex) == graph.end()) {
            graph[vertex] = std::vector<int>();
        }
    }
    
    void addEdge(int v1, int v2) {
        // Ensure both vertices exist
        if (graph.find(v1) == graph.end()) {
            addVertex(v1);
        }
        if (graph.find(v2) == graph.end()) {
            addVertex(v2);
        }
        graph[v1].push_back(v2);
    }

    void removeVertex(int vertex) {
        if (graph.find(vertex) == graph.end()) {
            return;
        }
        // Remove edges pointing to this node
        for (auto& pair : graph) {
            auto& edges = pair.second;
            edges.erase(
                std::remove(edges.begin(), edges.end(), vertex), 
                edges.end());
        }
        // Remove the node and its edges
        graph.erase(vertex);
    }
    
    void bfs(int start) {
        std::unordered_set<int> visited;
        std::queue<int> queue;
        
        queue.push(start);
        visited.insert(start);
        
        while (!queue.empty()) {
            int vertex = queue.front();
            queue.pop();  // Note: C++'s queue.pop() 
                          // doesn't return the value
            std::cout << vertex << " ";
            
            for (int neighbor : graph[vertex]) {
                if (visited.find(neighbor) == 
                    visited.end()) {
                    visited.insert(neighbor);
                    queue.push(neighbor);
                }
            }
        }
        std::cout << std::endl;
    }
};

int main() {
    Graph g;
    
    g.addEdge(0, 1);
    g.addEdge(0, 2);
    g.addEdge(1, 2);
    g.addEdge(2, 0);
    g.addEdge(2, 3);
    g.addEdge(3, 3);
    
    std::cout << "Breadth First Traversal " 
              << "(starting from vertex 2):" 
              << std::endl;
    g.bfs(2);
    
    return 0;
}