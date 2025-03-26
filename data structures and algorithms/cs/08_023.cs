using System;
using System.Linq;

public class IntervalCoverageOptimization
{
   public static int MinTeamMembers(int[][] intervals,
                                    int K)
   {
      Array.Sort(intervals, (a, b) =>
         a[0].CompareTo(b[0]));

      bool[] covered = new bool[intervals.Length];
      int teamCount = 0;

      while (!AllCovered(covered))
      {
         teamCount++;

         int earliestUncovered = -1;
         for (int i = 0; i < intervals.Length; i++)
         {
            if (!covered[i])
            {
               earliestUncovered = i;
               break;
            }
         }

         if (earliestUncovered == -1)
         {
            break;
         }

         int shiftStart = intervals[earliestUncovered][0];
         int shiftEnd = shiftStart + K;

         for (int i = 0; intervals.Length; i++)
         {
            if (!covered[i] && intervals[i][0] >=
                shiftStart && intervals[i][1] <=
                shiftEnd)
            {
               covered[i] = true;
            }
         }
      }

      return teamCount;
   }

   private static bool AllCovered(bool[] covered)
   {
      return covered.All(c => c);
   }

   public static void Main(string[] args)
   {
      int[][] intervals = {
            new int[] { 1, 3 },
            new int[] { 2, 5 },
            new int[] { 6, 8 },
            new int[] { 8, 10 },
            new int[] { 11, 12 }
        };
      int K = 5;
      Console.WriteLine("Minimum team members needed: "
                        + MinTeamMembers(intervals, K));
      // Output: 2
   }
}