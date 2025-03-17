void testDijkstra() {
  // Test Case 1: Simple path
  Graph g1;
  g1.addEdge("Dallas", "Chicago", 920);
  g1.addEdge("Dallas", "Memphis", 410);
  g1.addEdge("Chicago", "Boston", 850);
  g1.addEdge("Memphis", "Boston", 1200);
  g1.addEdge("Memphis", "Chicago", 480);
  
  auto result1 = g1.dijkstra("Dallas");
  auto& distances1 = result1.first;
  auto& paths1 = result1.second;
  
  // Assert distances
  assert(distances1["Dallas"] == 0 && 
        "Test case 1 distances failed");
  assert(distances1["Chicago"] == 890 && 
        "Test case 1 distances failed");
  assert(distances1["Memphis"] == 410 && 
        "Test case 1 distances failed");
  assert(distances1["Boston"] == 1740 && 
        "Test case 1 distances failed");
  
  // Assert paths
  assert(paths1["Dallas"] == 
        std::vector<std::string>{"Dallas"} && 
        "Test case 1 paths failed");
  assert(paths1["Chicago"] == 
        std::vector<std::string>{"Dallas", "Memphis", 
        "Chicago"} && "Test case 1 paths failed");
  assert(paths1["Memphis"] == 
        std::vector<std::string>{"Dallas", "Memphis"} && 
        "Test case 1 paths failed");
  assert(paths1["Boston"] == 
        std::vector<std::string>{
            "Dallas", "Memphis", "Chicago", "Boston"} && 
        "Test case 1 paths failed");
  std::cout << "Test case 1 passed!" << std::endl;
  
  // Test Case 2: Disconnected graph
  Graph g2;
  g2.addEdge("Dallas", "Chicago", 920);
  g2.addEdge("Atlanta", "Miami", 610);
  
  auto result2 = g2.dijkstra("Dallas");
  auto& distances2 = result2.first;
  auto& paths2 = result2.second;
  
  assert(distances2["Chicago"] == 920 && 
        "Test case 2 reachable distance failed");
  assert(distances2["Atlanta"] == 
        std::numeric_limits<int>::max() && 
        "Test case 2 unreachable distance failed");
  assert(distances2["Miami"] == 
        std::numeric_limits<int>::max() && 
        "Test case 2 unreachable distance failed");
  assert(paths2.find("Atlanta") == paths2.end() && 
         paths2.find("Miami") == paths2.end() && 
        "Test case 2 unreachable paths failed");
  std::cout << "Test case 2 passed!" << std::endl;
  
  // Test Case 3: Cyclic graph
  Graph g3;
  g3.addEdge("Dallas", "Chicago", 920);
  g3.addEdge("Chicago", "Atlanta", 590);
  g3.addEdge("Atlanta", "Dallas", 780);
  g3.addEdge("Chicago", "Boston", 850);
  
  auto result3 = g3.dijkstra("Dallas");
  auto& distances3 = result3.first;
  auto& paths3 = result3.second;
  
  assert(distances3["Dallas"] == 0 && 
        "Test case 3 distances failed");
  assert(distances3["Chicago"] == 920 && 
        "Test case 3 distances failed");
  assert(distances3["Atlanta"] == 1510 && 
        "Test case 3 distances failed");
  assert(distances3["Boston"] == 1770 && 
        "Test case 3 distances failed");
  assert(paths3["Boston"] == 
        std::vector<std::string>{"Dallas", "Chicago", 
        "Boston"} && "Test case 3 paths failed");
  std::cout << "Test case 3 passed!" << std::endl;
  
  // Test Case 4: Multiple paths to same destination
  Graph g4;
  g4.addEdge("Dallas", "Chicago", 920);
  g4.addEdge("Dallas", "Memphis", 410);
  g4.addEdge("Chicago", "Boston", 850);
  g4.addEdge("Memphis", "Boston", 1400);
  g4.addEdge("Dallas", "Boston", 1800);
  
  auto result4 = g4.dijkstra("Dallas");
  auto& distances4 = result4.first;
  auto& paths4 = result4.second;
  
  assert(distances4["Boston"] == 1770 && 
        "Test case 4 distance failed");
  assert(paths4["Boston"] == 
        std::vector<std::string>{"Dallas", "Chicago", 
        "Boston"} && "Test case 4 path failed");
  std::cout << "Test case 4 passed!" << std::endl;
  
  // Test Case 5: Large weights
  Graph g5;
  g5.addEdge("Dallas", "Chicago", 1000000);
  g5.addEdge("Chicago", "Boston", 2000000);
  
  auto result5 = g5.dijkstra("Dallas");
  auto& distances5 = result5.first;
  
  assert(distances5["Boston"] == 3000000 && 
        "Test case 5 large weights failed");
  std::cout << "Test case 5 passed!" << std::endl;
  
  std::cout << "\nAll test cases passed successfully! "
            << "Your implementation handles:" << std::endl;
  std::cout << "Basic shortest path finding" << std::endl;
  std::cout << "Disconnected graphs" << std::endl;
  std::cout << "Cyclic graphs" << std::endl;
  std::cout << "Multiple paths to same destination" 
            << std::endl;
  std::cout << "Large weight values" << std::endl;
}