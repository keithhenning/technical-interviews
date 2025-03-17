/**
 * Find fastest route between restaurant and customer
 */
public static List<String> findFastestDeliveryRoute(
      String restaurant, String customer, 
      Map<String[], TrafficData> trafficData) {
   // Create routing graph
   Graph graph = new Graph();
   
   // Add roads with current traffic conditions
   for (Map.Entry<String[], TrafficData> entry : 
         trafficData.entrySet()) {
      String[] road = entry.getKey();
      TrafficData traffic = entry.getValue();
      
      // Calculate estimated travel time
      int time = calculateTravelTime(traffic);
      
      // Add weighted edge to graph
      graph.addEdge(road[0], road[1], time);
   }
   
   // Run Dijkstra's algorithm
   Map.Entry<Map<String, Integer>, 
         Map<String, List<String>>> result = 
         graph.dijkstra(restaurant);
   Map<String, List<String>> paths = result.getValue();
   
   // Return optimal route
   return paths.get(customer);
}