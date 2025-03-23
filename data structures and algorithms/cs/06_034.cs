using System;
using System.Collections.Generic;

public static class PositionUtils
{
   public static bool ComparePositions(
      int[] pos1, int[] pos2, int[] goal,
      Dictionary<string, double> fScore)
   {
      // Get f-scores for both positions
      double f1 = fScore[ArrayToString(pos1)];
      double f2 = fScore[ArrayToString(pos2)];

      if (f1 == f2)
      {
         // Prefer positions closer to goal
         double h1 = Heuristic(pos1, goal);
         double h2 = Heuristic(pos2, goal);
         return h1 < h2;
      }

      return f1 < f2;
   }

   private static string ArrayToString(int[] array)
   {
      return string.Join(",", array);
   }

   private static double Heuristic(
      int[] pos, int[] goal)
   {
      // Implement your heuristic function here
      return 0.0;
   }
}
