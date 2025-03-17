int dijkstraWithTarget(const std::string& start, 
                      const std::string& target) {
    // Initialize distances
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
    
    while (!pq.empty()) {
        auto current = pq.top();
        pq.pop();
        std::string currentNode = current.second;
        int currentDistance = current.first;
        
        // Stop when we reach our target
        if (currentNode == target) {
            return distances[target];
        }
        
        // Skip if we've found a longer path
        if (currentDistance > distances[currentNode]) {
            continue;
        }
        
        // Process neighbors
        for (const Edge& edge : graph[currentNode]) {
            // Rest of Dijkstra implementation...
        }
    }
    
    return std::numeric_limits<int>::max(); // Target not reachable
}