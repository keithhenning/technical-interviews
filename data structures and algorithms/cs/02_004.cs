using System;
using System.Collections.Generic;

class Solution {
    // Function to merge overlapping intervals
    public int[][] Merge(int[][] intervals) {
        // Handle empty input case
        if (intervals.Length == 0) {
            return new int[0][];
        }

        // Sort intervals by start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // Use list to build result dynamically
        List<int[]> result = new List<int[]>();
        result.Add(intervals[0]);

        // Iterate through remaining intervals
        for (int i = 1; i < intervals.Length; i++) {
            int[] current = intervals[i];
            int[] lastMerged = result[result.Count - 1];

            // Check if current interval overlaps
            if (current[0] <= lastMerged[1]) {
                // Merge by updating end time
                lastMerged[1] = Math.Max(lastMerged[1], current[1]);
            } else {
                // If no overlap, add to result
                result.Add(current);
            }
        }

        // Convert list to array
        return result.ToArray();
    }

    // Test function to verify implementation
    public static void TestMergeCSharp() {
        // Test case with intervals
        int[][] intervals = new int[][] {
            new int[] { 1, 3 }, new int[] { 2, 6 },
            new int[] { 8, 10 }, new int[] { 15, 18 }
        };
        int[][] result = new Solution().Merge(intervals);

        Console.Write("C# Result: [");
        for (int i = 0; i < result.Length; i++) {
            Console.Write("[" + result[i][0] + "," 
                + result[i][1] + "]");
            if (i < result.Length - 1) {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");
        // Expected: [[1,6],[8,10],[15,18]]
    }

    public static void Main(string[] args) {
        TestMergeCSharp();
    }
}