// Adaptive heuristic function based on grid type
static double adaptiveHeuristic(
      const std::vector<int>& a,
      const std::vector<int>& b,
      const std::string& gridType) {
   // For grid with only cardinal directions
   if (gridType == "manhattan") {
      return std::abs(a[0] - b[0]) + std::abs(a[1] - b[1]);
   }
   // Allows diagonal movement
   else if (gridType == "chebyshev") {
      return std::max(std::abs(a[0] - b[0]), 
                    std::abs(a[1] - b[1]));
   }
   return 0;
}