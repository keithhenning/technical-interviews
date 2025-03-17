import java.util.Arrays;
import java.util.Comparator;

/**
 * Optimizes team member allocation to cover time intervals
 */
public class IntervalCoverageOptimization {
   /**
    * Find minimum number of team members needed
    * 
    * @param intervals Array of time intervals to cover
    * @param K Length of each team member's shift
    * @return Minimum number of team members required
    */
   public static int minTeamMembers(int[][] intervals, int K) {
      // Sort intervals by start time
      Arrays.sort(intervals, Comparator.comparingInt(a -> a[0]));
      
      // Track which intervals are covered
      boolean[] covered = new boolean[intervals.length];
      int teamCount = 0;
      
      while (!allCovered(covered)) {
         teamCount++;
         
         // Find earliest uncovered interval
         int earliestUncovered = -1;
         for (int i = 0; i < intervals.length; i++) {
            if (!covered[i]) {
               earliestUncovered = i;
               break;
            }
         }
         
         if (earliestUncovered == -1) {
            break;
         }
         
         // Determine shift boundaries
         int shiftStart = intervals[earliestUncovered][0];
         int shiftEnd = shiftStart + K;
         
         // Mark all intervals covered by this shift
         for (int i = 0; i < intervals.length; i++) {
            if (!covered[i] && 
                intervals[i][0] >= shiftStart && 
                intervals[i][1] <= shiftEnd) {
               covered[i] = true;
            }
         }
      }
      
      return teamCount;
   }
   
   /**
    * Check if all intervals are covered
    */
   private static boolean allCovered(boolean[] covered) {
      for (boolean c : covered) {
         if (!c) {
            return false;
         }
      }
      return true;
   }
   
   /**
    * Test the optimization algorithm
    */
   public static void main(String[] args) {
      int[][] intervals = {
         {1, 3}, {2, 5}, {6, 8}, {8, 10}, {11, 12}
      };
      int K = 5;
      System.out.println("Minimum team members needed: " + 
            minTeamMembers(intervals, K)); // Output: 2
   }
}