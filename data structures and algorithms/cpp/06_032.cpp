// Class for A* with dynamic grid updates
class DynamicAstar {
private:
   // Grid representation
   std::vector<std::vector<int>> grid;
   // Cache for previously computed paths
   std::unordered_map<std::string, 
                    std::vector<std::vector<int>>> cachedPaths;
   
   // Helper function to convert position to string key
   std::string posToString(const std::vector<int>& pos) {
      return std::to_string(pos[0]) + "," + 
             std::to_string(pos[1]);
   }
   
public:
   // Constructor
   DynamicAstar(const std::vector<std::vector<int>>& g) 
      : grid(g) {}
   
   // Update grid with multiple changes
   void updateGrid(
         const std::map<std::vector<int>, int>& changes) {
      // Update grid with new values
      for (const auto& change : changes) {
         const std::vector<int>& pos = change.first;
         grid[pos[0]][pos[1]] = change.second;
      }
      
      // Invalidate affected cached paths
      invalidateCachedPaths(changes);
   }
};