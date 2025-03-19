using System;
using System.Collections.Generic;

public class MatrixCircuit
{
   private static readonly int[][] DIRECTIONS = new int[][] { 
      new int[] { 0, 1 }, 
      new int[] { 1, 0 }, 
      new int[] { 0, -1 }, 
      new int[] { -1, 0 } 
   };

   public static bool CanCompleteCircuit(
      int[][] matrix,
      int startRow, 
      int startCol)
   {
      if (matrix[startRow][startCol] == 1)
      {
         return false;
      }

      int rows = matrix.Length;
      int cols = matrix[0].Length;
      HashSet<Pair> visited = new HashSet<Pair>();

      return Dfs(
         matrix, 
         startRow, 
         startCol, 
         startRow, 
         startCol,
         0, 
         visited, 
         rows, 
         cols);
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
      if (row == startRow && col == startCol && 
         pathLength >= 3)
      {
         return true;
      }

      visited.Add(new Pair(row, col));

      foreach (int[] dir in DIRECTIONS)
      {
         int newRow = row + dir[0];
         int newCol = col + dir[1];

         if (IsValidMove(matrix, newRow, newCol, rows, cols))
         {
            Pair newPos = new Pair(newRow, newCol);
            if (!visited.Contains(newPos) ||
               (newRow == startRow && 
                newCol == startCol &&
                pathLength >= 3))
            {
               if (Dfs(
                  matrix, 
                  startRow, 
                  startCol, 
                  newRow, 
                  newCol,
                  pathLength + 1, 
                  visited, 
                  rows, 
                  cols))
               {
                  return true;
               }
            }
         }
      }

      visited.Remove(new Pair(row, col));
      return false;
   }

   private static bool IsValidMove(
      int[][] matrix, 
      int row,
      int col, 
      int rows, 
      int cols)
   {
      return row >= 0 && row < rows && 
         col >= 0 && col < cols &&
         matrix[row][col] == 0;
   }

   public class Pair
   {
      public int Row { get; }
      public int Col { get; }

      public Pair(int row, int col)
      {
         this.Row = row;
         this.Col = col;
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
         return 31 * Row + Col;
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
