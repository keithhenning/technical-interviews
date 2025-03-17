// Memory-efficient A* implementation
static std::vector<std::vector<int>> astarMemoryEfficient(
      const std::vector<std::vector<int>>& grid,
      const std::vector<int>& start,
      const std::vector<int>& goal) {
   
   // Helper function to convert position to string key
   auto posToString = [](const std::vector<int>& pos) {
      return std::to_string(pos[0]) + "," + 
             std::to_string(pos[1]);
   };
   
   // Store only essential information
   std::unordered_map<std::string, std::vector<int>> parent;
   std::unordered_map<std::string, int> gScore;
   gScore[posToString(start)] = 0;
   
   // Use class for neighbors to avoid creating full lists
   class NeighborGenerator {
   private:
      const std::vector<std::vector<int>>& grid;
      
   public:
      NeighborGenerator(const std::vector<std::vector<int>>& g)
         : grid(g) {}
         
      std::vector<std::vector<int>> getNeighbors(
            const std::vector<int>& pos) {
         std::vector<std::vector<int>> neighbors;
         const int directions[4][2] = {
            {0, 1}, {1, 0}, {0, -1}, {-1, 0}
         };
         
         for (const auto& dir : directions) {
            std::vector<int> newPos = {
               pos[0] + dir[0], 
               pos[1] + dir[1]
            };
            if (isValid(newPos)) {
               neighbors.push_back(newPos);
            }
         }
         return neighbors;
      }
      
      // Check if position is valid and not an obstacle
      bool isValid(const std::vector<int>& pos) {
         return pos[0] >= 0 && pos[0] < grid.size() && 
                pos[1] >= 0 && pos[1] < grid[0].size() && 
                grid[pos[0]][pos[1]] != 1;
      }
   };
   
   NeighborGenerator neighborGen(grid);
   
   // Rest of A* implementation...
   return std::vector<std::vector<int>>();
}