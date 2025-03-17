import java.util.HashSet;
import java.util.Set;

/**
 * Checks if a circuit can be formed in a binary matrix
 */
public class MatrixCircuit {
   // Directions: right, down, left, up
   private static final int[][] DIRECTIONS = 
      {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
   
   /**
    * Determines if a circuit can be made from start position
    */
   public static boolean canCompleteCircuit(int[][] matrix, 
         int startRow, int startCol) {
      if (matrix[startRow][startCol] == 1) {
         return false;  // Invalid starting position
      }
      
      int rows = matrix.length;
      int cols = matrix[0].length;
      Set<Pair> visited = new HashSet<>();
      
      return dfs(matrix, startRow, startCol, startRow, startCol, 
            0, visited, rows, cols);
   }
   
   /**
    * DFS to find a valid circuit
    */
   private static boolean dfs(int[][] matrix, int startRow, 
         int startCol, int row, int col, 
         int pathLength, Set<Pair> visited, 
         int rows, int cols) {
      // Complete circuit found (back to start after ≥3 moves)
      if (row == startRow && col == startCol && pathLength >= 3) {
         return true;
      }
      
      visited.add(new Pair(row, col));
      
      for (int[] dir : DIRECTIONS) {
         int newRow = row + dir[0];
         int newCol = col + dir[1];
         
         // Check if move is valid
         if (isValidMove(matrix, newRow, newCol, rows, cols)) {
            Pair newPos = new Pair(newRow, newCol);
            // Allow revisiting start position to complete circuit
            if (!visited.contains(newPos) || 
                (newRow == startRow && newCol == startCol && 
                pathLength >= 3)) {
               
               if (dfs(matrix, startRow, startCol, newRow, newCol,
                     pathLength + 1, visited, rows, cols)) {
                  return true;
               }
            }
         }
      }
      
      // Backtrack
      visited.remove(new Pair(row, col));
      return false;
   }
   
   /**
    * Check if position is valid and not a wall
    */
   private static boolean isValidMove(int[][] matrix, int row, 
         int col, int rows, int cols) {
      return row >= 0 && row < rows && col >= 0 && col < cols && 
            matrix[row][col] == 0;
   }
   
   /**
    * Helper class for coordinate pairs
    */
   static class Pair {
      int row, col;
      
      Pair(int row, int col) {
         this.row = row;
         this.col = col;
      }
      
      @Override
      public boolean equals(Object obj) {
         if (this == obj) return true;
         if (obj == null || getClass() != obj.getClass()) 
            return false;
         Pair pair = (Pair) obj;
         return row == pair.row && col == pair.col;
      }
      
      @Override
      public int hashCode() {
         return 31 * row + col;
      }
   }
   
   /**
    * Test the circuit finder
    */
   public static void main(String[] args) {
      int[][] matrix = {
         {0, 1, 0, 0},
         {0, 0, 0, 1},
         {1, 1, 0, 0},
         {0, 0, 0, 0}
      };
      
      System.out.println("Circuit possible: " + 
            canCompleteCircuit(matrix, 0, 0));  // true
   }
}