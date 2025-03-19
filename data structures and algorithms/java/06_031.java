public static List<int[]> astarMemoryEfficient(int[][] grid, int[] start, int[] goal) {
   // Store only essential information
   Map<String, int[]> parent = new HashMap<>();
   Map<String, Integer> gScore = new HashMap<>();
   gScore.put(Arrays.toString(start), 0);
   
   // Use function for neighbors to avoid creating full lists
   class NeighborGenerator {
       public Iterable<int[]> getNeighbors(int[] pos) {
           List<int[]> neighbors = new ArrayList<>();
           int[][] directions = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
           
           for (int[] dir : directions) {
               int[] newPos = {pos[0] + dir[0], pos[1] + dir[1]};
               if (isValid(newPos)) {
                   neighbors.add(newPos);
               }
           }
           return neighbors;
       }
       
       private boolean isValid(int[] pos) {
           return pos[0] >= 0 && pos[0] < grid.length && 
                  pos[1] >= 0 && pos[1] < grid[0].length && 
                  grid[pos[0]][pos[1]] != 1;
       }
   }
   
   NeighborGenerator neighborGen = new NeighborGenerator();
   
   // Rest of A* implementation...
   return null;
}