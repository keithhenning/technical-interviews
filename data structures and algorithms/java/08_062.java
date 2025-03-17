public class Solution {
   public int numIslands(char[][] grid) {
      // Validate input
      if (grid == null || grid.length == 0 || 
          grid[0].length == 0) {
         return 0;
      }
      
      int rows = grid.length;
      int cols = grid[0].length;
      int count = 0;
      
      // Scan grid for islands
      for (int i = 0; i < rows; i++) {
         for (int j = 0; j < cols; j++) {
            if (grid[i][j] == '1') {
               count++;
               dfs(grid, i, j, rows, cols);
            }
         }
      }
      
      return count;
   }
   
   // Depth-first search to mark island
   private void dfs(char[][] grid, int i, int j, 
         int rows, int cols) {
      // Boundary and visited check
      if (i < 0 || i >= rows || j < 0 || 
          j >= cols || grid[i][j] == '0') {
         return;
      }
      
      // Mark as visited
      grid[i][j] = '0';
      
      // Explore adjacent cells
      dfs(grid, i+1, j, rows, cols);
      dfs(grid, i-1, j, rows, cols);
      dfs(grid, i, j+1, rows, cols);
      dfs(grid, i, j-1, rows, cols);
   }
}