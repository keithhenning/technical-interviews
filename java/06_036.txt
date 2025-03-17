/**
 * Get neighboring positions with movement costs
 */
public static List<Map.Entry<int[], Integer>> 
      getNeighborsWeighted(int[] pos, int[][] grid) {
   // Store neighbors with their weights
   List<Map.Entry<int[], Integer>> neighbors = 
         new ArrayList<>();
   
   // Four cardinal directions
   int[][] directions = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
   for (int[] dir : directions) {
      int newX = pos[0] + dir[0];
      int newY = pos[1] + dir[1];
      
      // Check if position is valid
      if (validPosition(newX, newY, grid)) {
         // Get movement cost from grid
         int weight = grid[newX][newY];
         neighbors.add(new AbstractMap.SimpleEntry<>(
               new int[]{newX, newY}, weight));
      }
   }
   
   return neighbors;
}