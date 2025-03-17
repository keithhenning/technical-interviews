// Compare positions for A* open set ordering
static bool comparePositions(
      const std::vector<int>& pos1,
      const std::vector<int>& pos2,
      const std::vector<int>& goal,
      const std::unordered_map<std::string, double>& fScore) {
   
   // Helper to convert position to string key
   auto posToString = [](const std::vector<int>& pos) {
      return std::to_string(pos[0]) + "," + 
             std::to_string(pos[1]);
   };
   
   // Get f-scores for both positions
   double f1 = fScore.at(posToString(pos1));
   double f2 = fScore.at(posToString(pos2));
   
   if (f1 == f2) {
      // If f-scores are equal, prefer positions 
      // closer to goal (tie-breaking)
      double h1 = heuristic(pos1, goal);
      double h2 = heuristic(pos2, goal);
      return h1 < h2;
   }
   
   // Otherwise, compare by f-score
   return f1 < f2;
}