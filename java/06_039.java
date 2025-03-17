/**
 * Comprehensive tests for Dijkstra's algorithm
 */
public static void testDijkstra() {
   // Test Case 1: Simple path
   Graph g1 = new Graph();
   g1.addEdge("Dallas", "Chicago", 920);
   g1.addEdge("Dallas", "Memphis", 410);
   g1.addEdge("Chicago", "Boston", 850);
   g1.addEdge("Memphis", "Boston", 1200);
   g1.addEdge("Memphis", "Chicago", 480);
   
   Map.Entry<Map<String, Integer>, 
         Map<String, List<String>>> result1 = 
         g1.dijkstra("Dallas");
   Map<String, Integer> distances1 = result1.getKey();
   Map<String, List<String>> paths1 = result1.getValue();
   
   // Verify correct distances
   assert distances1.get("Dallas") == 0 : 
      "Test case 1 distances failed";
   assert distances1.get("Chicago") == 890 : 
      "Test case 1 distances failed";
   assert distances1.get("Memphis") == 410 : 
      "Test case 1 distances failed";
   assert distances1.get("Boston") == 1740 : 
      "Test case 1 distances failed";
   
   // Verify correct paths
   assert paths1.get("Dallas").equals(List.of("Dallas")) : 
      "Test case 1 paths failed";
   assert paths1.get("Chicago").equals(
      List.of("Dallas", "Memphis", "Chicago")) : 
      "Test case 1 paths failed";
   assert paths1.get("Memphis").equals(
      List.of("Dallas", "Memphis")) : 
      "Test case 1 paths failed";
   assert paths1.get("Boston").equals(
      List.of("Dallas", "Memphis", "Chicago", "Boston")) : 
      "Test case 1 paths failed";
   System.out.println("Test case 1 passed!");
   
   // Test Case 2: Disconnected graph
   Graph g2 = new Graph();
   g2.addEdge("Dallas", "Chicago", 920);
   g2.addEdge("Atlanta", "Miami", 610);
   
   Map.Entry<Map<String, Integer>, 
         Map<String, List<String>>> result2 = 
         g2.dijkstra("Dallas");
   Map<String, Integer> distances2 = result2.getKey();
   Map<String, List<String>> paths2 = result2.getValue();
   
   // Verify reachable and unreachable nodes
   assert distances2.get("Chicago") == 920 : 
      "Test case 2 reachable distance failed";
   assert distances2.get("Atlanta") == Integer.MAX_VALUE : 
      "Test case 2 unreachable distance failed";
   assert distances2.get("Miami") == Integer.MAX_VALUE : 
      "Test case 2 unreachable distance failed";
   assert !paths2.containsKey("Atlanta") && 
         !paths2.containsKey("Miami") : 
      "Test case 2 unreachable paths failed";
   System.out.println("Test case 2 passed!");
   
   // Test Case 3: Cyclic graph
   Graph g3 = new Graph();
   g3.addEdge("Dallas", "Chicago", 920);
   g3.addEdge("Chicago", "Atlanta", 590);
   g3.addEdge("Atlanta", "Dallas", 780);
   g3.addEdge("Chicago", "Boston", 850);
   
   Map.Entry<Map<String, Integer>, 
         Map<String, List<String>>> result3 = 
         g3.dijkstra("Dallas");
   Map<String, Integer> distances3 = result3.getKey();
   Map<String, List<String>> paths3 = result3.getValue();
   
   // Verify cyclic graph distances and paths
   assert distances3.get("Dallas") == 0 : 
      "Test case 3 distances failed";
   assert distances3.get("Chicago") == 920 : 
      "Test case 3 distances failed";
   assert distances3.get("Atlanta") == 1510 : 
      "Test case 3 distances failed";
   assert distances3.get("Boston") == 1770 : 
      "Test case 3 distances failed";
   assert paths3.get("Boston").equals(
      List.of("Dallas", "Chicago", "Boston")) : 
      "Test case 3 paths failed";
   System.out.println("Test case 3 passed!");
   
   // Test Case 4: Multiple paths to destination
   Graph g4 = new Graph();
   g4.addEdge("Dallas", "Chicago", 920);
   g4.addEdge("Dallas", "Memphis", 410);
   g4.addEdge("Chicago", "Boston", 850);
   g4.addEdge("Memphis", "Boston", 1400);
   g4.addEdge("Dallas", "Boston", 1800);
   
   Map.Entry<Map<String, Integer>, 
         Map<String, List<String>>> result4 = 
         g4.dijkstra("Dallas");
   Map<String, Integer> distances4 = result4.getKey();
   Map<String, List<String>> paths4 = result4.getValue();
   
   // Verify optimal path is found
   assert distances4.get("Boston") == 1770 : 
      "Test case 4 distance failed";
   assert paths4.get("Boston").equals(
      List.of("Dallas", "Chicago", "Boston")) : 
      "Test case 4 path failed";
   System.out.println("Test case 4 passed!");
   
   // Test Case 5: Large weights
   Graph g5 = new Graph();
   g5.addEdge("Dallas", "Chicago", 1000000);
   g5.addEdge("Chicago", "Boston", 2000000);
   
   Map.Entry<Map<String, Integer>, 
         Map<String, List<String>>> result5 = 
         g5.dijkstra("Dallas");
   Map<String, Integer> distances5 = result5.getKey();
   
   // Verify large weight handling
   assert distances5.get("Boston") == 3000000 : 
      "Test case 5 large weights failed";
   System.out.println("Test case 5 passed!");
   
   System.out.println("\nAll test cases passed successfully!");
   System.out.println("Your implementation handles:");
   System.out.println("Basic shortest path finding");
   System.out.println("Disconnected graphs");
   System.out.println("Cyclic graphs");
   System.out.println("Multiple paths to same destination");
   System.out.println("Large weight values");
}