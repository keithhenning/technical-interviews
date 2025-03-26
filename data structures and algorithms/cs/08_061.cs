using System;

public class Solution
{
   public int MaxProductPath(int[][] grid)
   {
      if (grid == null || grid.Length == 0 ||
         grid[0].Length == 0)
      {
         return 0;
      }

      int rows = grid.Length;
      int cols = grid[0].Length;
      long[][] maxDp = new long[rows][];
      long[][] minDp = new long[rows][];

      for (int i = 0; i < rows; i++)
      {
         maxDp[i] = new long[cols];
         minDp[i] = new long[cols];
      }

      maxDp[0][0] = minDp[0][0] = grid[0][0];

      for (int j = 1; j < cols; j++)
      {
         maxDp[0][j] = maxDp[0][j - 1] * grid[0][j];
         minDp[0][j] = minDp[0][j - 1] * grid[0][j];
      }

      for (int i = 1; i < rows; i++)
      {
         maxDp[i][0] = maxDp[i - 1][0] * grid[i][0];
         minDp[i][0] = minDp[i - 1][0] * grid[i][0];
      }

      for (int i = 1; i < rows; i++)
      {
         for (int j = 1; j < cols; j++)
         {
            if (grid[i][j] >= 0)
            {
               maxDp[i][j] = Math.Max(
                  maxDp[i - 1][j],
                  maxDp[i][j - 1]) * grid[i][j];
               minDp[i][j] = Math.Min(
                  minDp[i - 1][j],
                  minDp[i][j - 1]) * grid[i][j];
            }
            else
            {
               maxDp[i][j] = Math.Min(
                  minDp[i - 1][j],
                  minDp[i][j - 1]) * grid[i][j];
               minDp[i][j] = Math.Max(
                  maxDp[i - 1][j],
                  maxDp[i][j - 1]) * grid[i][j];
            }
         }
      }

      return (int)(maxDp[rows - 1][cols - 1] % 1000000007);
   }
}