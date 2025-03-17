public class NQueens {
   /**
    * Solve N-Queens problem using backtracking
    * 
    * @param n Board size and number of queens
    * @return Solution board or null if no solution exists
    */
   public static int[][] solveNQueens(int n) {
      // Initialize empty board
      int[][] board = new int[n][n];
      
      // Solve starting from leftmost column
      if (!solveUtil(board, 0, n)) {
         System.out.println("Solution does not exist");
         return null;
      }
      
      return board;
   }
   
   /**
    * Recursive backtracking function to solve N-Queens
    */
   private static boolean solveUtil(int[][] board, int col, 
         int n) {
      // Base case: all queens placed successfully
      if (col >= n) {
         return true;
      }
      
      // Try placing queen in each row of current column
      for (int i = 0; i < n; i++) {
         // Check if current position is safe
         if (isSafe(board, i, col, n)) {
            // Place queen
            board[i][col] = 1;
            
            // Recur to place rest of queens
            if (solveUtil(board, col + 1, n)) {
               return true;
            }
            
            // Backtrack if placement doesn't lead to solution
            board[i][col] = 0;
         }
      }
      
      // No solution found with current configuration
      return false;
   }
   
   /**
    * Check if placing queen at (row,col) is safe
    */
   private static boolean isSafe(int[][] board, int row, 
         int col, int n) {
      // Check row on left side
      for (int j = 0; j < col; j++) {
         if (board[row][j] == 1) {
            return false;
         }
      }
      
      // Check upper diagonal on left side
      for (int i = row, j = col; i >= 0 && j >= 0; i--, j--) {
         if (board[i][j] == 1) {
            return false;
         }
      }
      
      // Check lower diagonal on left side
      for (int i = row, j = col; i < n && j >= 0; i++, j--) {
         if (board[i][j] == 1) {
            return false;
         }
      }
      
      return true;
   }
   
   /**
    * Test the N-Queens solution
    */
   public static void main(String[] args) {
      int n = 4; // 4x4 board with 4 queens
      int[][] result = solveNQueens(n);
      
      if (result != null) {
         System.out.println(n + "-Queens Solution:");
         for (int i = 0; i < result.length; i++) {
            for (int j = 0; j < result.length; j++) {
               System.out.print(result[i][j] + " ");
            }
            System.out.println();
         }
      }
   }
}