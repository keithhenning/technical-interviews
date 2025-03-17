// Define move direction constants
final int[][] DIAGONAL_MOVES = {
   {1, 1}, {1, -1}, {-1, 1}, {-1, -1}
};
final int[][] STRAIGHT_MOVES = {
   {0, 1}, {1, 0}, {0, -1}, {-1, 0}
};

/**
 * Get neighbors including diagonal movements
 */
public static List<Map.Entry<int[], Double>> 
      getNeighborsDiagonal(int[] pos, int[][] grid) {
   // Store neighbors with movement costs
   List<Map.Entry<int[], Double>> neighbors = 
         new ArrayList<>();
   
   // Process both diagonal and straight moves
   for (int[][] moveSet : 
         new int[][][]{DIAGONAL_MOVES, STRAIGHT_MOVES}) {
      for (int[] dir : moveSet) {
         int newX = pos[0] + dir[0];
         int newY = pos[1] + dir[1];
         
         // Set cost based on movement type
         double cost = (dir[0] != 0 && dir[1] != 0) ? 
               1.414 : 1.0; // &#x221a;2 for diagonal
         
         // Add valid neighbors with costs
         if (validPosition(newX, newY, grid)) {
            neighbors.add(new AbstractMap.SimpleEntry<>(
                  new int[]{newX, newY}, cost));
         }
      }
   }
   
   return neighbors;
}