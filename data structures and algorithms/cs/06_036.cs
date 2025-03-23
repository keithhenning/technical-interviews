using System;
using System.Collections.Generic;

public static class NeighborUtils
{
   /**
    * Get neighboring positions with movement costs
    */
   public static List<KeyValuePair<int[], int>>
   GetNeighborsWeighted(int[] pos, int[][] grid)
   {
      // Store neighbors with their weights
      List<KeyValuePair<int[], int>> neighbors =
         new List<KeyValuePair<int[], int>>();

      // Four cardinal directions
      int[][] directions = {
         new int[] { 0, 1 },
         new int[] { 1, 0 },
         new int[] { 0, -1 },
         new int[] { -1, 0 }
      };
      foreach (var dir in directions)
      {
         int newX = pos[0] + dir[0];
         int newY = pos[1] + dir[1];

         // Check if position is valid
         if (ValidPosition(newX, newY, grid))
         {
            // Get movement cost from grid
            int weight = grid[newX][newY];
            neighbors.Add(
               new KeyValuePair<int[], int>(
                  new int[] { newX, newY }, weight
               )
            );
         }
      }

      return neighbors;
   }

   private static bool ValidPosition(int x, int y, int[][] grid)
   {
      return x >= 0 && x < grid.Length &&
             y >= 0 && y < grid[0].Length;
   }
}
