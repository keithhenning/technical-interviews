class DynamicAstar {
   private int[][] grid;
   private Map<String, List<int[]>> cachedPaths;
   
   public DynamicAstar(int[][] grid) {
       this.grid = grid;
       this.cachedPaths = new HashMap<>();
   }
   
   public void updateGrid(Map<int[], Integer> changes) {
       // Update grid with new values
       for (Map.Entry<int[], Integer> change : changes.entrySet()) {
           int[] pos = change.getKey();
           grid[pos[0]][pos[1]] = change.getValue();
       }
       
       // Invalidate affected cached paths
       invalidateCachedPaths(changes);
   }
}