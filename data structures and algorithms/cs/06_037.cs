using System;
using System.Collections.Generic;

public static class NeighborUtils
{
   // Define move direction constants
   private static readonly int[][] DIAGONAL_MOVES = {
        new int[] {1, 1}, new int[] {1, -1},
        new int[] {-1, 1}, new int[] {-1, -1}
    };
   private static readonly int[][] STRAIGHT_MOVES = {
        new int[] {0, 1}, new int[] {1, 0},
        new int[] {0, -1}, new int[] {-1, 0}
    };

   /**
    * Get neighbors including diagonal movements
    */
   public static List<KeyValuePair<int[], double>>
   GetNeighborsDiagonal(int[] pos, int[][] grid)
   {
      // Store neighbors with movement costs
      List<KeyValuePair<int[], double>> neighbors =
          new List<KeyValuePair<int[], double>>();

      // Process both diagonal and straight moves
      foreach (var moveSet in new int[][][] {
          DIAGONAL_MOVES, STRAIGHT_MOVES })
      {
         foreach (var dir in moveSet)
         {
            int newX = pos[0] + dir[0];
            int newY = pos[1] + dir[1];

            // Set cost based on movement type
            double cost = (dir[0] != 0 && dir[1] != 0) ?
                1.414 : 1.0; // √2 for diagonal

            // Add valid neighbors with costs
            if (ValidPosition(newX, newY, grid))
            {
               neighbors.Add(new KeyValuePair<int[], double>(
                   new int[] { newX, newY }, cost));
            }
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
