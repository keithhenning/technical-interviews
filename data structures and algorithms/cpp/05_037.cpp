class Graph {
public:
    void removeNode(int node) {
        // First attempt - not very efficient!
        for (auto& current_node : nodes) {
            for (auto it = current_node.edges.begin(); 
                 it != current_node.edges.end(); ) {
                if (it->connects_to(node)) {
                    it = current_node.edges.erase(it);
                } else {
                    ++it;
                }
            }
        }
        nodes.erase(
            std::remove_if(nodes.begin(), nodes.end(), 
                [node](const Node& n) { 
                    return n.id == node; 
                }), 
            nodes.end());
    }
};