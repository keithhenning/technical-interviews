using System;
using System.Collections.Generic;

public class NumberOfIslands
{
   public static int NumIslands(char[][] grid)
   {
      if (grid == null ||
            grid.Length == 0 ||
            grid[0].Length == 0
         )
      {
         return 0;
      }

      int rows = grid.Length;
      int cols = grid[0].Length;
      int count = 0;

      for (int r = 0; r < rows; r++)
      {
         for (int c = 0; c < cols; c++)
         {
            if (grid[r][c] == '1')
            {
               count++;  // Found a new island
                         // Mark all connected as visited
               Dfs(grid, r, c);
            }
         }
      }

      return count;
   }

   private static void Dfs(char[][] grid, int r, int c)
   {
      int rows = grid.Length;
      int cols = grid[0].Length;

      // Check if out of bounds or if cell is water
      if (r < 0 ||
            c < 0 ||
            r >= rows ||
            c >= cols ||
            grid[r][c] == '0'
         )
      {
         return;
      }

      // Mark as visited by changing to water
      grid[r][c] = '0';

      // Check all four directions
      Dfs(grid, r + 1, c);  // down
      Dfs(grid, r - 1, c);  // up
      Dfs(grid, r, c + 1);  // right
      Dfs(grid, r, c - 1);  // left
   }

   public static void Main(string[] args)
   {
      char[][] grid = new char[][] {
            new char[] {'1','1','0','0','0'},
            new char[] {'1','1','0','0','0'},
            new char[] {'0','0','1','0','0'},
            new char[] {'0','0','0','1','1'}
        };

      Console.WriteLine(NumIslands(grid));  // 3
   }
}