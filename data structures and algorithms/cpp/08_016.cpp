#include <vector>
#include <string>
#include <unordered_map>
#include <unordered_set>
#include <queue>

std::vector<std::string> resolveDependencies(
    const std::unordered_map
        std::string, 
        std::vector<std::string>>& tasks) {
    
    // Build adjacency list and in-degree count
    std::unordered_map
        std::string, 
        std::vector<std::string>> graph;
    std::unordered_map<std::string, int> inDegree;
    
    for (const auto& [task, _] : tasks) {
        graph[task] = std::vector<std::string>();
        inDegree[task] = 0;
    }
    
    for (const auto& [task, dependencies] : tasks) {
        for (const auto& dep : dependencies) {
            graph[dep].push_back(task);
            inDegree[task]++;
        }
    }
    
    // Start with tasks that have no dependencies
    std::queue<std::string> q;
    for (const auto& [task, degree] : inDegree) {
        if (degree == 0) {
            q.push(task);
        }
    }
    
    std::vector<std::string> result;
    
    // Process tasks level by level
    while (!q.empty()) {
        std::string current = q.front();
        q.pop();
        result.push_back(current);
        
        // Reduce in-degree of dependent tasks
        for (const auto& dependent : graph[current]) {
            inDegree[dependent]--;
            if (inDegree[dependent] == 0) {
                q.push(dependent);
            }
        }
    }
    
    // Check if we have a valid order (no cycles)
    if (result.size() != tasks.size()) {
        return {}; // Cycle detected, return empty vector
    }
    
    return result;
}