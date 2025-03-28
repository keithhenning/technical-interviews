using System;
using System.Collections.Generic;

public class MatrixCircuit
{
   private static readonly int[][] DIRECTIONS = {
      new int[] { 0, 1 },
      new int[] { 1, 0 },
      new int[] { 0, -1 },
      new int[] { -1, 0 }
   };

   public static bool CanCompleteCircuit(int[][] matrix, int startRow, int startCol)
   {
      if (matrix[startRow][startCol] == 1)
      {
         return false;
      }

      int rows = matrix.Length;
      int cols = matrix[0].Length;
      var visited = new HashSet<Pair>();

      return Dfs(matrix, startRow, startCol, startRow,
         startCol, 0, visited, rows, cols);
   }

   private static bool Dfs(
      int[][] matrix,
      int startRow,
      int startCol,
      int row,
      int col,
      int pathLength,
      HashSet<Pair> visited,
      int rows,
      int cols)
   {
      bool isValidCircuit = row == startRow &&
         col == startCol && pathLength >= 3;
      if (isValidCircuit)
      {
         return true;
      }

      visited.Add(new Pair(row, col));

      foreach (var dir in DIRECTIONS)
      {
         int newRow = row + dir[0];
         int newCol = col + dir[1];

         if (IsValidMove(matrix, newRow, newCol, rows, cols))
         {
            var newPos = new Pair(newRow, newCol);
            bool canVisit = !visited.Contains(newPos) ||
                           (newRow == startRow &&
                           newCol == startCol && pathLength >= 3);

            if (canVisit)
            {
               bool found = Dfs(matrix, startRow, startCol,
                               newRow, newCol, pathLength + 1,
                               visited, rows, cols);
               if (found)
               {
                  return true;
               }
            }
         }
      }

      visited.Remove(new Pair(row, col));
      return false;
   }

   private static bool IsValidMove(int[][] matrix, int row,
                              int col, int rows, int cols)
   {
      bool inBounds = row >= 0 && row < rows &&
         col >= 0 && col < cols;
      return inBounds && matrix[row][col] == 0;
   }

   public class Pair
   {
      public int Row { get; set; }
      public int Col { get; set; }

      public Pair(int row, int col)
      {
         Row = row;
         Col = col;
      }

      public override bool Equals(object obj)
      {
         if (this == obj) return true;
         if (obj == null || GetType() != obj.GetType())
            return false;
         Pair pair = (Pair)obj;
         return Row == pair.Row && Col == pair.Col;
      }

      public override int GetHashCode()
      {
         return HashCode.Combine(Row, Col);
      }
   }

   public static void Main(string[] args)
   {
      int[][] matrix = {
         new int[] { 0, 1, 0, 0 },
         new int[] { 0, 0, 0, 1 },
         new int[] { 1, 1, 0, 0 },
         new int[] { 0, 0, 0, 0 }
      };

      Console.WriteLine(
         "Circuit possible: " +
         CanCompleteCircuit(matrix, 0, 0));
   }
}