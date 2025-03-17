class Graph {
private:
    // Our friendship list!
    std::unordered_map<int, 
        std::vector<int>> adj_list;  
    
public:
    void removeNode(int node) {
        // Get this person's friends before removing them
        if (adj_list.find(node) == adj_list.end()) {
            return;
        }
            
        // Tell all their friends they're leaving
        for (int friend_id : adj_list[node]) {
            auto& friend_list = adj_list[friend_id];
            friend_list.erase(
                std::remove(friend_list.begin(), 
                            friend_list.end(), node),
                friend_list.end()
            );
        }
            
        // Remove their friend list entirely
        adj_list.erase(node);
    }
};