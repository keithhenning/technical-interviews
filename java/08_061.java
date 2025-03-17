public class Solution {
   public int maxProductPath(int[][] grid) {
      // Validate input
      if (grid == null || grid.length == 0 || 
          grid[0].length == 0) {
         return 0;
      }
      
      int rows = grid.length;
      int cols = grid[0].length;
      long[][] maxDp = new long[rows][cols];
      long[][] minDp = new long[rows][cols];
      
      // Initialize first cell
      maxDp[0][0] = minDp[0][0] = grid[0][0];
      
      // Initialize first row
      for (int j = 1; j < cols; j++) {
         maxDp[0][j] = maxDp[0][j-1] * grid[0][j];
         minDp[0][j] = minDp[0][j-1] * grid[0][j];
      }
      
      // Initialize first column
      for (int i = 1; i < rows; i++) {
         maxDp[i][0] = maxDp[i-1][0] * grid[i][0];
         minDp[i][0] = minDp[i-1][0] * grid[i][0];
      }
      
      // Fill dp arrays
      for (int i = 1; i < rows; i++) {
         for (int j = 1; j < cols; j++) {
            if (grid[i][j] >= 0) {
               // Positive cell handling
               maxDp[i][j] = Math.max(
                  maxDp[i-1][j], maxDp[i][j-1]) * 
                  grid[i][j];
               minDp[i][j] = Math.min(
                  minDp[i-1][j], minDp[i][j-1]) * 
                  grid[i][j];
            } else {
               // Negative cell handling
               maxDp[i][j] = Math.min(
                  minDp[i-1][j], minDp[i][j-1]) * 
                  grid[i][j];
               minDp[i][j] = Math.max(
                  maxDp[i-1][j], maxDp[i][j-1]) * 
                  grid[i][j];
            }
         }
      }
      
      // Return max product
      return (int) (maxDp[rows-1][cols-1] % 
         1000000007);
   }
}