/**
 * Finds maximum diagonal sum in a square matrix
 */
public class Solution {
   public int maxDiagonalSum(int[][] matrix) {
      if (matrix == null || matrix.length == 0 || 
          matrix[0].length == 0) {
         return 0;
      }
      
      int n = matrix.length;
      int maxSum = Integer.MIN_VALUE;
      
      // Check diagonals starting from top row
      for (int col = 0; col < n; col++) {
         int diagonalSum = 0;
         int r = 0, c = col;
         
         while (r < n && c < n) {
            diagonalSum += matrix[r][c];
            r++;
            c++;
         }
         
         maxSum = Math.max(maxSum, diagonalSum);
      }
      
      // Check diagonals starting from leftmost column
      for (int row = 1; row < n; row++) {
         int diagonalSum = 0;
         int r = row, c = 0;
         
         while (r < n && c < n) {
            diagonalSum += matrix[r][c];
            r++;
            c++;
         }
         
         maxSum = Math.max(maxSum, diagonalSum);
      }
      
      return maxSum;
   }
}