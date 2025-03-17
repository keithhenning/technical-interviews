import java.util.Stack;

/**
 * Solution for finding largest rectangle in histogram
 */
public class LargestRectangle {
   /**
    * Calculate largest rectangle area in histogram
    */
   public static int largestRectangleArea(int[] heights) {
      Stack<Integer> stack = new Stack<>();
      int maxArea = 0;
      int i = 0;
      
      // Process all heights
      while (i < heights.length) {
         // Push index if empty or height is increasing
         if (stack.isEmpty() || 
               heights[stack.peek()] <= heights[i]) {
            stack.push(i);
            i++;
         } else {
            // Pop and calculate area when height decreases
            int top = stack.pop();
            
            // Calculate width based on stack state
            int width = stack.isEmpty() ? i : 
                  i - stack.peek() - 1;
            
            // Update maximum area
            maxArea = Math.max(maxArea, heights[top] * width);
         }
      }
      
      // Process remaining elements in stack
      while (!stack.isEmpty()) {
         int top = stack.pop();
         int width = stack.isEmpty() ? i : 
               i - stack.peek() - 1;
         maxArea = Math.max(maxArea, heights[top] * width);
      }
      
      return maxArea;
   }

   /**
    * Example usage
    */
   public static void main(String[] args) {
      int[] heights = {2, 1, 5, 6, 2, 3};
      System.out.println("Largest rectangle area: " + 
            largestRectangleArea(heights)); // Output: 10
   }
}