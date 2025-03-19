using System;
using System.Collections.Generic;

public class Solution 
{
   private int gridSize;
   private int[][] compatibility;
   private int[][] directions = new int[][] 
   {
      new int[] {0, 1}, 
      new int[] {1, 0},
      new int[] {0, -1}, 
      new int[] {-1, 0}
   };

   public int MaxKennelCompatibility(
      int[][] compatibility) 
   {
      int n = compatibility.Length;
      gridSize = (int) Math.Sqrt(n);

      if (gridSize * gridSize != n) 
      {
         return -1;
      }

      this.compatibility = compatibility;
      int[][] assignment = new int[gridSize][];
      for (int i = 0; i < gridSize; i++) 
      {
         assignment[i] = new int[gridSize];
         Array.Fill(assignment[i], -1);
      }
      bool[] used = new bool[n];

      return Backtrack(
         assignment, 
         0, 
         0, 
         used, 
         0, 
         0);
   }

   private int Backtrack(
      int[][] assignment,
      int row, 
      int col, 
      bool[] used,
      int currentScore, 
      int bestScore) 
   {
      if (row == gridSize) 
      {
         return Math.Max(currentScore, bestScore);
      }

      int nextRow = row, nextCol = col + 1;
      if (nextCol == gridSize) 
      {
         nextRow = row + 1;
         nextCol = 0;
      }

      for (int dog = 0; dog < used.Length; dog++) 
      {
         if (!used[dog]) 
         {
            used[dog] = true;
            assignment[row][col] = dog;

            int additionalScore = 0;
            foreach (int[] dir in directions) 
            {
               int adjRow = row + dir[0];
               int adjCol = col + dir[1];

               if (IsValid(adjRow, adjCol) &&
                  assignment[adjRow][adjCol] != -1) 
               {
                  additionalScore +=
                     compatibility[dog]
                     [assignment[adjRow][adjCol]];
               }
            }

            bestScore = Backtrack(
               assignment,
               nextRow, 
               nextCol, 
               used,
               currentScore + additionalScore,
               bestScore);

            assignment[row][col] = -1;
            used[dog] = false;
         }
      }

      return bestScore;
   }

   private bool IsValid(int row, int col) 
   {
      return row >= 0 && row < gridSize &&
         col >= 0 && col < gridSize;
   }
}
