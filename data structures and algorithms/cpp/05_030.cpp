class DirectedGraph {
private:
    std::unordered_map<std::string, 
        std::vector<std::string>> graph;
    
public:
    void add_relationship(
        const std::string& from_node, 
        const std::string& to_node) {
        if (graph.find(from_node) == graph.end()) {
            graph[from_node] = 
                std::vector<std::string>();
        }
        graph[from_node].push_back(to_node);
    }
};