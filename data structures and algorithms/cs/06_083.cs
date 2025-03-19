using System;
using System.Collections.Generic;

public class LargestRectangle {
    /**
     * Calculate largest rectangle area in histogram
     */
    public static int LargestRectangleArea(int[] heights) {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;
        int i = 0;

        // Process all heights
        while (i < heights.Length) {
            // Push index if empty or height is increasing
            if (stack.Count == 0 || heights[stack.Peek()] <= heights[i]) {
                stack.Push(i);
                i++;
            } else {
                // Pop and calculate area when height decreases
                int top = stack.Pop();

                // Calculate width based on stack state
                int width = stack.Count == 0 ? i : i - stack.Peek() - 1;

                // Update maximum area
                maxArea = Math.Max(maxArea, heights[top] * width);
            }
        }

        // Process remaining elements in stack
        while (stack.Count > 0) {
            int top = stack.Pop();
            int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
            maxArea = Math.Max(maxArea, heights[top] * width);
        }

        return maxArea;
    }

    /**
     * Example usage
     */
    public static void Main(string[] args) {
        int[] heights = { 2, 1, 5, 6, 2, 3 };
        Console.WriteLine("Largest rectangle area: " + LargestRectangleArea(heights)); // Output: 10
    }
}