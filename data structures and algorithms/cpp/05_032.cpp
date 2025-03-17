class UndirectedGraph {
private:
    std::unordered_map<std::string, 
        std::vector<std::string>> graph;
    
public:
    void add_relationship(
        const std::string& node1, 
        const std::string& node2) {
        // Ensure both nodes exist in the graph
        if (graph.find(node1) == graph.end()) {
            graph[node1] = 
                std::vector<std::string>();
        }
        if (graph.find(node2) == graph.end()) {
            graph[node2] = 
                std::vector<std::string>();
        }
            
        // Add bidirectional relationship
        graph[node1].push_back(node2);
        graph[node2].push_back(node1);
    }
};