void bfs(int start) {
    std::unordered_set<int> visited;
    std::queue<int> queue;
    
    queue.push(start);
    visited.insert(start);
    
    while (!queue.empty()) {
        int vertex = queue.front();
        queue.pop();  // C++'s queue.pop() doesn't return the value
        std::cout << vertex << " ";
        
        for (int neighbor : graph[vertex]) {
            if (visited.find(neighbor) == visited.end()) {
                visited.insert(neighbor);
                queue.push(neighbor);
            }
        }
    }
    std::cout << std::endl;
}