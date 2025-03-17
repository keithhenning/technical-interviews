#include <iostream>
#include <vector>
#include <unordered_map>
#include <map>
#include <queue>
#include <limits>
#include <stdexcept>

/**
 * A graph implementation with Dijkstra's shortest path algorithm.
 */
class Graph {
private:
    // Edge class to represent connections between nodes
    struct Edge {
        std::string destination;
        int weight;
        
        Edge(const std::string& dest, int w) 
            : destination(dest), weight(w) {}
    };
    
    // Adjacency list representation of the graph
    std::unordered_map<std::string, std::vector<Edge>> graph;
    
public:
    /**
     * Initialize an empty graph.
     */
    Graph() {}
    
    /**
     * Add a weighted edge to the graph.
     */
    void addEdge(const std::string& fromNode, 
                const std::string& toNode, int weight) {
        // Check for negative weights
        if (weight < 0) {
            throw std::invalid_argument(
                "Negative weights not allowed in Dijkstra's");
        }
        
        // Ensure both nodes exist in the graph
        if (graph.find(fromNode) == graph.end()) {
            graph[fromNode] = std::vector<Edge>();
        }
        
        // Add the edge
        graph[fromNode].push_back(Edge(toNode, weight));
        
        // Ensure the destination node exists in the graph
        if (graph.find(toNode) == graph.end()) {
            graph[toNode] = std::vector<Edge>();
        }
    }
    
    /**
     * Find shortest paths from start node to all other nodes
     * using Dijkstra's algorithm.
     */
    std::pair<std::unordered_map<std::string, int>, 
            std::unordered_map<std::string, 
                std::vector<std::string>>> dijkstra(
                    const std::string& start) {
        // Check if start node exists
        if (graph.find(start) == graph.end()) {
            throw std::invalid_argument(
                "Start node '" + start + "' not in graph");
        }
        
        // Initialize distances to infinity for all nodes
        std::unordered_map<std::string, int> distances;
        for (const auto& node : graph) {
            distances[node.first] = std::numeric_limits<int>::max();
        }
        distances[start] = 0;
        
        // Custom comparator for priority queue
        auto comparator = [](const std::pair<int, std::string>& a,
                          const std::pair<int, std::string>& b) {
            return a.first > b.first;
        };
        
        // Priority queue to store (distance, node)
        std::priority_queue<std::pair<int, std::string>,
                          std::vector<std::pair<int, std::string>>,
                          decltype(comparator)> pq(comparator);
        pq.push({0, start});
        
        // Track shortest paths
        std::unordered_map<std::string, 
                         std::vector<std::string>> paths;
        std::vector<std::string> startPath;
        startPath.push_back(start);
        paths[start] = startPath;
        
        // Process nodes in order of distance
        while (!pq.empty()) {
            // Get node with smallest distance
            auto current = pq.top();
            pq.pop();
            int currentDistance = current.first;
            std::string currentNode = current.second;
            
            // Skip if we've found a longer path
            if (currentDistance > distances[currentNode]) {
                continue;
            }
            
            // Check all neighbors
            for (const Edge& edge : graph[currentNode]) {
                std::string neighbor = edge.destination;
                int weight = edge.weight;
                
                // Calculate new distance
                int distance = currentDistance + weight;
                
                // Update if shorter path is found
                if (distance < distances[neighbor]) {
                    distances[neighbor] = distance;
                    
                    // Create new path by copying current path
                    // and adding the neighbor
                    std::vector<std::string> newPath = 
                                        paths[currentNode];
                    newPath.push_back(neighbor);
                    paths[neighbor] = newPath;
                    
                    // Add to priority queue
                    pq.push({distance, neighbor});
                }
            }
        }
        
        return {distances, paths};
    }
};

/**
 * Example usage
 */
int main() {
    // Create a graph representing a road network
    Graph g;
    
    // Add edges (fromCity, toCity, distanceInMiles)
    g.addEdge("Dallas", "Chicago", 920);
    g.addEdge("Dallas", "Memphis", 410);
    g.addEdge("Chicago", "Boston", 850);
    g.addEdge("Memphis", "Atlanta", 335);
    g.addEdge("Memphis", "Chicago", 480);
    g.addEdge("Atlanta", "Miami", 610);
    g.addEdge("Atlanta", "Boston", 1070);
    g.addEdge("Boston", "Miami", 1450);
    
    // Run Dijkstra's algorithm from Dallas
    std::string startNode = "Dallas";
    auto result = g.dijkstra(startNode);
    
    auto& distances = result.first;
    auto& paths = result.second;
    
    // Print results
    std::cout << "Shortest distances from " << startNode << ":\n";
    for (const auto& entry : distances) {
        std::cout << "  To " << entry.first << ": " 
                << entry.second << " miles\n";
    }
    
    std::cout << "\nShortest paths:\n";
    for (const auto& entry : paths) {
        std::string node = entry.first;
        const std::vector<std::string>& path = entry.second;
        
        if (node != startNode) {
            std::cout << "  To " << node << ": ";
            
            // Join path with arrows
            for (size_t i = 0; i < path.size(); ++i) {
                std::cout << path[i];
                if (i < path.size() - 1) {
                    std::cout << " -> ";
                }
            }
            
            std::cout << " (distance: " << distances[node] 
                    << " miles)\n";
        }
    }
    
    return 0;
}