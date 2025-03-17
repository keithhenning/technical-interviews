#include <iostream>
#include <vector>
#include <map>
#include <queue>
#include <string>

struct Operation {
    int arrivalTime;
    int targetNode;
    int sourceNode;
    std::string key;
    int value;
    int opTimestamp;
    
    Operation(int arrivalTime, int targetNode, 
             int sourceNode, const std::string& key, 
             int value, int opTimestamp)
        : arrivalTime(arrivalTime), 
          targetNode(targetNode), 
          sourceNode(sourceNode),
          key(key), value(value), 
          opTimestamp(opTimestamp) {}
          
    bool operator>(const Operation& other) const {
        return arrivalTime > other.arrivalTime;
    }
};

std::vector<std::map<std::string, int>> finalCacheState(
        int n, 
        const std::vector
            std::tuple<int, std::string, int, int>>& operations, 
        const std::vector<std::vector<int>>& delays) {
    
    // Initialize caches for each node
    std::vector<std::map<std::string, int>> caches(n);
    std::vector<std::map<std::string, int>> timestamps(n);
    
    // Priority queue for events with timestamps
    std::priority_queue
        Operation, 
        std::vector<Operation>, 
        std::greater<Operation>> eventQueue;
    
    // Add initial operations to queue
    for (const auto& op : operations) {
        int nodeId = std::get<0>(op);
        std::string key = std::get<1>(op);
        int value = std::get<2>(op);
        int timestamp = std::get<3>(op);
        
        // Process operation at source node immediately
        eventQueue.emplace(timestamp, nodeId, nodeId, 
                          key, value, timestamp);
        
        // Schedule propagation to other nodes
        for (int targetNode = 0; targetNode < n; 
             targetNode++) {
            if (targetNode != nodeId) {
                int arrivalTime = timestamp + 
                    delays[nodeId][targetNode];
                eventQueue.emplace(arrivalTime, targetNode, 
                                  nodeId, key, value, 
                                  timestamp);
            }
        }
    }
    
    // Process all events
    while (!eventQueue.empty()) {
        Operation op = eventQueue.top();
        eventQueue.pop();
        
        int targetNode = op.targetNode;
        const std::string& key = op.key;
        int value = op.value;
        int opTimestamp = op.opTimestamp;
        
        // Apply if newer than what we have
        auto it = timestamps[targetNode].find(key);
        if (it == timestamps[targetNode].end() || 
            it->second < opTimestamp) {
            caches[targetNode][key] = value;
            timestamps[targetNode][key] = opTimestamp;
        }
    }
    
    return caches;
}

void printResult(
        const std::vector<std::map<std::string, int>>& 
        caches) {
    std::cout << "[";
    for (size_t i = 0; i < caches.size(); i++) {
        std::cout << "{";
        bool first = true;
        for (const auto& entry : caches[i]) {
            if (!first) std::cout << ", ";
            std::cout << "\"" << entry.first << "\": " 
                      << entry.second;
            first = false;
        }
        std::cout << "}";
        if (i < caches.size() - 1) std::cout << ", ";
    }
    std::cout << "]" << std::endl;
}

int main() {
    int nodes = 3;
    std::vector<std::tuple<int, std::string, int, int>> 
        operations = {
            {0, "x", 10, 1},  // Node 0 sets x=10 at time 1
            {1, "y", 20, 2},  // Node 1 sets y=20 at time 2
            {2, "x", 30, 3},  // Node 2 sets x=30 at time 3
            {0, "y", 40, 4}   // Node 0 sets y=40 at time 4
        };
    std::vector<std::vector<int>> delays = {
        {0, 2, 3},  // Delays from node 0 to others
        {2, 0, 1},  // Delays from node 1 to others
        {3, 1, 0}   // Delays from node 2 to others
    };
    
    std::vector<std::map<std::string, int>> result = 
        finalCacheState(nodes, operations, delays);
    printResult(result);
    
    return 0;
}