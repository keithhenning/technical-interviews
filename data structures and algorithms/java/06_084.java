public static int trap(int[] height) {
   if (height == null || height.length == 0) {
       return 0;
   }
   
   int n = height.length;
   int[] leftMax = new int[n];
   int[] rightMax = new int[n];
   
   // Fill leftMax
   leftMax[0] = height[0];
   for (int i = 1; i < n; i++) {
       leftMax[i] = Math.max(leftMax[i-1], height[i]);
   }
   
   // Fill rightMax
   rightMax[n-1] = height[n-1];
   for (int i = n-2; i >= 0; i--) {
       rightMax[i] = Math.max(rightMax[i+1], height[i]);
   }
   
   // Calculate trapped water
   int water = 0;
   for (int i = 0; i < n; i++) {
       water += Math.min(leftMax[i], rightMax[i]) - height[i];
   }
   
   return water;
}

// Example
public static void main(String[] args) {
   int[] height = {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
   System.out.println(trap(height));  // Output: 6
}