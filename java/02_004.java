import java.util.*;

class Solution {
   // Function to merge overlapping intervals
   public int[][] merge(int[][] intervals) {
      // Handle empty input case
      if (intervals.length == 0) {
         return new int[0][0];
      }
      
      // Sort intervals by start time
      Arrays.sort(intervals, (a, b) -> 
         Integer.compare(a[0], b[0]));
      
      // Use list to build result dynamically
      List<int[]> result = new ArrayList<>();
      result.add(intervals[0]);
      
      // Iterate through remaining intervals
      for (int i = 1; i < intervals.length; i++) {
         int[] current = intervals[i];
         int[] lastMerged = result.get(result.size() - 1);
         
         // Check if current interval overlaps
         if (current[0] <= lastMerged[1]) {
            // Merge by updating end time
            lastMerged[1] = Math.max(lastMerged[1], 
               current[1]);
         } else {
            // If no overlap, add to result
            result.add(current);
         }
      }
      
      // Convert list to array
      return result.toArray(new int[result.size()][]);
   }

   // Test function to verify implementation
   public static void testMergeJava() {
      // Test case with intervals
      int[][] intervals = {{1, 3}, {2, 6}, {8, 10}, 
         {15, 18}};
      int[][] result = new Solution().merge(intervals);
      
      System.out.print("Java Result: [");
      for (int i = 0; i < result.length; i++) {
         System.out.print("[" + result[i][0] + "," + 
            result[i][1] + "]");
         if (i < result.length - 1) {
            System.out.print(", ");
         }
      }
      System.out.println("]");
      // Expected: [[1,6],[8,10],[15,18]]
   }

   public static void main(String[] args) {
      testMergeJava();
   }
}