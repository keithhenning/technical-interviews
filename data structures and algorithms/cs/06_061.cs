using System;
using System.Collections.Generic;

public class NQueens {
   /**
    * Solve N-Queens problem using backtracking
    */
   public static int[][] solveNQueens(int n) {
      // Initialize board
      int[][] board = new int[n][];
      for (int i = 0; i < n; i++) {
         board[i] = new int[n];
      }
      
      if (!solveUtil(board, 0, n)) {
         return null;
      }
      
      return board;
   }

   /**
    * Check if position is safe for queen placement
    */
   private static bool isSafe(int[][] board, int row, 
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
   private static bool solveUtil(int[][] board, int col, 
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
   public static List<string> formatBoard(int[][] board) {
      if (board == null) {
         return null;
      }
      
      List<string> formatted = new List<string>();
      foreach (int[] row in board) {
         StringBuilder sb = new StringBuilder();
         foreach (int cell in row) {
            sb.Append(cell == 1 ? 'Q' : '.');
         }
         formatted.Add(sb.ToString());
      }
      return formatted;
   }

   /**
    * Visualize board solution as string
    */
   public static string visualizeSolution(int[][] board) {
      if (board == null) {
         return "No solution exists";
      }
      
      List<string> formatted = formatBoard(board);
      return string.Join("\n", formatted);
   }

   /**
    * Main method for testing
    */
   public static void Main(string[] args) {
      Console.WriteLine("Testing different board sizes:");
      foreach (int n in new int[]{1, 2, 3, 4, 8}) {
         Console.WriteLine("\nTesting " + n + "x" + n + 
               " board:");
         int[][] solution = solveNQueens(n);
         Console.WriteLine(visualizeSolution(solution));
      }
   }
}

using NUnit.Framework;

/**
 * Test class for NQueens solution
 */
public class TestNQueens {
   private NQueens solver;

   [SetUp]
   public void SetUp() {
      solver = new NQueens();
   }

   /**
    * Test 1x1 board (should have solution)
    */
   [Test]
   public void Test1x1Board() {
      int[][] result = NQueens.solveNQueens(1);
      Assert.IsNotNull(result);
      Assert.AreEqual(1, result.Length);
      Assert.AreEqual(1, result[0][0]);
   }

   /**
    * Test 2x2 board (no solution)
    */
   [Test]
   public void Test2x2Board() {
      int[][] result = NQueens.solveNQueens(2);
      Assert.IsNull(result);
   }

   /**
    * Test 3x3 board (no solution)
    */
   [Test]
   public void Test3x3Board() {
      int[][] result = NQueens.solveNQueens(3);
      Assert.IsNull(result);
   }

   /**
    * Test 4x4 board (should have solution)
    */
   [Test]
   public void Test4x4Board() {
      int[][] result = NQueens.solveNQueens(4);
      Assert.IsNotNull(result);
      List<string> formatted = NQueens.formatBoard(result);
      Assert.AreEqual(4, formatted.Count);
      
      // Count queens to ensure there are exactly 4
      int queenCount = 0;
      foreach (string row in formatted) {
         queenCount += row.Count(ch => ch == 'Q');
      }
      Assert.AreEqual(4, queenCount);
   }

   /**
    * Test 8x8 board (should have solution)
    */
   [Test]
   public void Test8x8Board() {
      int[][] result = NQueens.solveNQueens(8);
      Assert.IsNotNull(result);
      List<string> formatted = NQueens.formatBoard(result);
      Assert.AreEqual(8, formatted.Count);
      
      // Count queens to ensure there are exactly 8
      int queenCount = 0;
      foreach (string row in formatted) {
         queenCount += row.Count(ch => ch == 'Q');
      }
      Assert.AreEqual(8, queenCount);
   }

   /**
    * Test no queens threaten each other
    */
   [Test]
   public void TestQueenThreats() {
      int n = 4;
      int[][] result = NQueens.solveNQueens(n);
      Assert.IsNotNull(result);
      
      // Check row threats (one queen per row)
      foreach (int[] row in result) {
         int sum = 0;
         foreach (int cell in row) {
            sum += cell;
         }
         Assert.AreEqual(1, sum);
      }
      
      // Check column threats (one queen per column)
      for (int j = 0; j < n; j++) {
         int sum = 0;
         for (int i = 0; i < n; i++) {
            sum += result[i][j];
         }
         Assert.AreEqual(1, sum);
      }
      
      // Check diagonal threats
      for (int i = 0; i < n; i++) {
         for (int j = 0; j < n; j++) {
            if (result[i][j] == 1) {
               // Check diagonals from each queen's position
               for (int k = 1; k < n; k++) {
                  // Check upper-right diagonal
                  if (i-k >= 0 && j+k < n) {
                     Assert.AreEqual(0, result[i-k][j+k]);
                  }
                  // Check lower-right diagonal
                  if (i+k < n && j+k < n) {
                     Assert.AreEqual(0, result[i+k][j+k]);
                  }
               }
            }
         }
      }
   }
}
