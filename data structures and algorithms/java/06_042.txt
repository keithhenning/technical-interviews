/**
 * Run Dijkstra's algorithm to find shortest path to target
 */
public int dijkstraWithTarget(String start, String target) {
   // Initialize distances
   Map<String, Integer> distances = new HashMap<>();
   for (String node : graph.keySet()) {
      distances.put(node, Integer.MAX_VALUE);
   }
   distances.put(start, 0);
   
   // Priority queue for processing nodes
   PriorityQueue<Map.Entry<Integer, String>> pq = 
      new PriorityQueue<>(
         Comparator.comparing(Map.Entry::getKey)
      );
   pq.add(new AbstractMap.SimpleEntry<>(0, start));
   
   while (!pq.isEmpty()) {
      Map.Entry<Integer, String> current = pq.poll();
      String currentNode = current.getValue();
      int currentDistance = current.getKey();
      
      // Early termination when target is reached
      if (currentNode.equals(target)) {
         return distances.get(target);
      }
      
      // Skip if better path already found
      if (currentDistance > distances.get(currentNode)) {
         continue;
      }
      
      // Process each neighbor
      for (Edge edge : graph.get(currentNode)) {
         String neighbor = edge.destination;
         int weight = edge.weight;
         
         // Calculate new distance
         int distance = currentDistance + weight;
         
         // Update if shorter path found
         if (distance < distances.get(neighbor)) {
            distances.put(neighbor, distance);
            pq.add(new AbstractMap.SimpleEntry<>(
               distance, neighbor));
         }
      }
   }
   
   // Target not reachable
   return Integer.MAX_VALUE;
}