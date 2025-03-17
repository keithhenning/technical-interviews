#include <vector>
#include <queue>
#include <unordered_map>
#include <tuple>

struct Request {
    int id;
    int size;
    
    Request(int id, int size) : id(id), size(size) {}
};

struct Server {
    int id;
    int capacity;
    int currentLoad;
    int lastActive;
    
    Server(int id, int capacity) 
        : id(id), capacity(capacity), currentLoad(0), 
          lastActive(0) {}
};

// Custom comparator for priority queue
struct ServerComparator {
    bool operator()(
            const std::tuple<int, int, int>& a, 
            const std::tuple<int, int, int>& b) {
        // Compare by load first
        if (std::get<0>(a) != std::get<0>(b)) {
            return std::get<0>(a) > std::get<0>(b); // Min heap
        }
        // If loads are equal, compare by last active time
        return std::get<1>(a) > std::get<1>(b); // Min heap
    }
};

std::vector<std::pair<int, int>> assignRequests(
        const std::vector<Request>& requests, 
        std::vector<Server>& servers) {
    // Create a map from server ID to Server object
    std::unordered_map<int, Server*> serverMap;
    for (auto& server : servers) {
        serverMap[server.id] = &server;
    }
    
    // Priority queue for servers: (load, lastActive, serverId)
    std::priority_queue
        std::tuple<int, int, int>, 
        std::vector<std::tuple<int, int, int>>, 
        ServerComparator> serverHeap;
    
    for (const auto& server : servers) {
        serverHeap.push(
            std::make_tuple(0, 0, server.id));
    }
    
    std::vector<std::pair<int, int>> assignments;
    int currentTime = 0;
    
    for (const auto& request : requests) {
        currentTime++;
        
        // Get least loaded server
        if (serverHeap.empty()) {
            break; // No available servers
        }
        
        auto [load, lastActive, serverId] = serverHeap.top();
        serverHeap.pop();
        
        Server* server = serverMap[serverId];
        
        // Check if server has capacity for this request
        if (server->currentLoad + request.size <= 
            server->capacity) {
            // Assign request to server
            server->currentLoad += request.size;
            server->lastActive = currentTime;
            assignments.push_back({server->id, request.id});
            
            // Put server back in heap with updated load
            serverHeap.push(std::make_tuple(
                server->currentLoad, 
                -currentTime, 
                server->id));
        }
    }
    
    return assignments;
}