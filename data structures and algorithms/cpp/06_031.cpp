// Identify jump points for JPS (Jump Point Search)
static std::vector<int> identifyJumpPoint(
      const std::vector<int>& node,
      const std::vector<int>& direction,
      const std::vector<std::vector<int>>& grid) {
   
   // Skip straight lines until finding a turn
   int x = node[0];
   int y = node[1];
   int dx = direction[0];
   int dy = direction[1];
   
   // Follow direction until forced neighbor is found
   while (validPosition(x + dx, y + dy, grid)) {
      x += dx;
      y += dy;
      
      // Check if this position forces a direction change
      if (hasForcedNeighbor(x, y, direction, grid)) {
         return std::vector<int>{x, y};
      }
   }
   
   // No jump point found
   return std::vector<int>(); // Empty vector
}