import java.util.ArrayList;
import java.util.List;

public class NQueens {
   /**
    * Solve N-Queens problem using backtracking
    */
   public static int[][] solveNQueens(int n) {
      // Initialize board
      int[][] board = new int[n][n];
      
      if (!solveUtil(board, 0, n)) {
         return null;
      }
      
      return board;
   }

   /**
    * Check if position is safe for queen placement
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
    * Recursive backtracking function
    */
   private static boolean solveUtil(int[][] board, int col, 
         int n) {
      // Base case: all queens placed
      if (col >= n) {
         return true;
      }

      // Try placing queen in each row of current column
      for (int i = 0; i < n; i++) {
         if (isSafe(board, i, col, n)) {
            // Place queen
            board[i][col] = 1;

            // Recur for next column
            if (solveUtil(board, col + 1, n)) {
               return true;
            }
            
            // Backtrack if no solution found
            board[i][col] = 0;
         }
      }
      
      return false;
   }

   /**
    * Format board for visualization
    */
   public static List<String> formatBoard(int[][] board) {
      if (board == null) {
         return null;
      }
      
      List<String> formatted = new ArrayList<>();
      for (int[] row : board) {
         StringBuilder sb = new StringBuilder();
         for (int cell : row) {
            sb.append(cell == 1 ? 'Q' : '.');
         }
         formatted.add(sb.toString());
      }
      return formatted;
   }

   /**
    * Visualize board solution as string
    */
   public static String visualizeSolution(int[][] board) {
      if (board == null) {
         return "No solution exists";
      }
      
      List<String> formatted = formatBoard(board);
      return String.join("\n", formatted);
   }

   /**
    * Main method for testing
    */
   public static void main(String[] args) {
      System.out.println("Testing different board sizes:");
      for (int n : new int[]{1, 2, 3, 4, 8}) {
         System.out.println("\nTesting " + n + "x" + n + 
               " board:");
         int[][] solution = solveNQueens(n);
         System.out.println(visualizeSolution(solution));
      }
   }
}

import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;
import java.util.List;

/**
 * Test class for NQueens solution
 */
public class TestNQueens {
   private NQueens solver;

   @Before
   public void setUp() {
      solver = new NQueens();
   }

   /**
    * Test 1x1 board (should have solution)
    */
   @Test
   public void test1x1Board() {
      int[][] result = NQueens.solveNQueens(1);
      assertNotNull(result);
      assertEquals(1, result.length);
      assertEquals(1, result[0][0]);
   }

   /**
    * Test 2x2 board (no solution)
    */
   @Test
   public void test2x2Board() {
      int[][] result = NQueens.solveNQueens(2);
      assertNull(result);
   }

   /**
    * Test 3x3 board (no solution)
    */
   @Test
   public void test3x3Board() {
      int[][] result = NQueens.solveNQueens(3);
      assertNull(result);
   }

   /**
    * Test 4x4 board (should have solution)
    */
   @Test
   public void test4x4Board() {
      int[][] result = NQueens.solveNQueens(4);
      assertNotNull(result);
      List<String> formatted = NQueens.formatBoard(result);
      assertEquals(4, formatted.size());
      
      // Count queens to ensure there are exactly 4
      int queenCount = 0;
      for (String row : formatted) {
         queenCount += row.chars().filter(ch -> ch == 'Q')
               .count();
      }
      assertEquals(4, queenCount);
   }

   /**
    * Test 8x8 board (should have solution)
    */
   @Test
   public void test8x8Board() {
      int[][] result = NQueens.solveNQueens(8);
      assertNotNull(result);
      List<String> formatted = NQueens.formatBoard(result);
      assertEquals(8, formatted.size());
      
      // Count queens to ensure there are exactly 8
      int queenCount = 0;
      for (String row : formatted) {
         queenCount += row.chars().filter(ch -> ch == 'Q')
               .count();
      }
      assertEquals(8, queenCount);
   }

   /**
    * Test no queens threaten each other
    */
   @Test
   public void testQueenThreats() {
      int n = 4;
      int[][] result = NQueens.solveNQueens(n);
      assertNotNull(result);
      
      // Check row threats (one queen per row)
      for (int[] row : result) {
         int sum = 0;
         for (int cell : row) {
            sum += cell;
         }
         assertEquals(1, sum);
      }
      
      // Check column threats (one queen per column)
      for (int j = 0; j < n; j++) {
         int sum = 0;
         for (int i = 0; i < n; i++) {
            sum += result[i][j];
         }
         assertEquals(1, sum);
      }
      
      // Check diagonal threats
      for (int i = 0; i < n; i++) {
         for (int j = 0; j < n; j++) {
            if (result[i][j] == 1) {
               // Check diagonals from each queen's position
               for (int k = 1; k < n; k++) {
                  // Check upper-right diagonal
                  if (i-k >= 0 && j+k < n) {
                     assertEquals(0, result[i-k][j+k]);
                  }
                  // Check lower-right diagonal
                  if (i+k < n && j+k < n) {
                     assertEquals(0, result[i+k][j+k]);
                  }
               }
            }
         }
      }
   }
}