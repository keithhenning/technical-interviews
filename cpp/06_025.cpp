static double heuristic(const std::vector<int>& a, 
                      const std::vector<int>& b) {
   // Manhattan distance - fast but may not be optimal
   return std::abs(a[0] - b[0]) + std::abs(a[1] - b[1]);
   
   // Euclidean distance - for diagonal movement
   // return std::sqrt(std::pow(a[0] - b[0], 2) + 
   //                std::pow(a[1] - b[1], 2));
}