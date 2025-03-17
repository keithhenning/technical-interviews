// Bidirectional A* implementation
static std::vector<std::vector<int>> bidirectionalAstar(
      const std::vector<std::vector<int>>& grid,
      const std::vector<int>& start,
      const std::vector<int>& goal) {
   
   // Helper function to convert position to string key
   auto posToString = [](const std::vector<int>& pos) {
      return std::to_string(pos[0]) + "," + 
             std::to_string(pos[1]);
   };
   
   // Initialize forward front (from start)
   std::unordered_map<std::string, int> forwardFront;
   forwardFront[posToString(start)] = 0;
   
   // Initialize backward front (from goal)
   std::unordered_map<std::string, int> backwardFront;
   backwardFront[posToString(goal)] = 0;
   
   // Continue search while both fronts have nodes
   while (!forwardFront.empty() && 
          !backwardFront.empty()) {
      // Expand both fronts, starting with smaller one
      std::string current;
      if (forwardFront.size() < backwardFront.size()) {
         current = expandFront(forwardFront);
      } else {
         current = expandFront(backwardFront);
      }
      
      // Check for intersection between the two fronts
      if (forwardFront.find(current) != 
          forwardFront.end() && 
          backwardFront.find(current) != 
          backwardFront.end()) {
         return reconstructPath(current);
      }
   }
   
   return std::vector<std::vector<int>>();
}