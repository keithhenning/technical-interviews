static std::vector<std::string> findFastestDeliveryRoute(
        const std::string& restaurant,
        const std::string& customer,
        const std::map<std::array<std::string, 2>, 
                      TrafficData>& trafficData) {
    // Create a new graph
    Graph graph;
    
    // Add roads with current traffic conditions
    for (const auto& entry : trafficData) {
        const auto& road = entry.first;
        const TrafficData& traffic = entry.second;
        
        // Calculate travel time based on traffic
        int time = calculateTravelTime(traffic);
        
        // Add edge to graph
        graph.addEdge(road[0], road[1], time);
    }
    
    // Find fastest route from restaurant to customer
    auto result = graph.dijkstra(restaurant);
    auto& paths = result.second;
    
    // Return the path to the customer
    return paths[customer];
}