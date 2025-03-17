import java.util.*;

public class Solution {
   private int gridSize;
   private int[][] compatibility;
   private int[][] directions = {{0, 1}, {1, 0}, 
                                  {0, -1}, {-1, 0}};
   
   public int maxKennelCompatibility(
         int[][] compatibility) {
      int n = compatibility.length;
      gridSize = (int) Math.sqrt(n);
      
      // Check for valid grid
      if (gridSize * gridSize != n) {
         return -1;
      }
      
      this.compatibility = compatibility;
      int[][] assignment = new int[gridSize][gridSize];
      boolean[] used = new boolean[n];
      
      // Initialize grid
      for (int i = 0; i < gridSize; i++) {
         Arrays.fill(assignment[i], -1);
      }
      
      return backtrack(assignment, 0, 0, used, 0, 0);
   }
   
   // Backtracking to maximize compatibility
   private int backtrack(int[][] assignment, 
         int row, int col, boolean[] used, 
         int currentScore, int bestScore) {
      // Grid fully filled
      if (row == gridSize) {
         return Math.max(currentScore, bestScore);
      }
      
      // Calculate next position
      int nextRow = row, nextCol = col + 1;
      if (nextCol == gridSize) {
         nextRow = row + 1;
         nextCol = 0;
      }
      
      // Try placing each dog
      for (int dog = 0; dog < used.length; dog++) {
         if (!used[dog]) {
            used[dog] = true;
            assignment[row][col] = dog;
            
            // Calculate compatibility with neighbors
            int additionalScore = 0;
            for (int[] dir : directions) {
               int adjRow = row + dir[0];
               int adjCol = col + dir[1];
               
               if (isValid(adjRow, adjCol) && 
                   assignment[adjRow][adjCol] != -1) {
                  additionalScore += 
                     compatibility[dog]
                     [assignment[adjRow][adjCol]];
               }
            }
            
            // Recursive exploration
            bestScore = backtrack(assignment, 
               nextRow, nextCol, used, 
               currentScore + additionalScore, 
               bestScore);
            
            // Backtrack
            assignment[row][col] = -1;
            used[dog] = false;
         }
      }
      
      return bestScore;
   }
   
   // Check grid boundaries
   private boolean isValid(int row, int col) {
      return row >= 0 && row < gridSize && 
             col >= 0 && col < gridSize;
   }
}