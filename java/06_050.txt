public static int maxArea(int[] height) {
   int left = 0;
   int right = height.length - 1;
   int maxArea = 0;
   
   while (left < right) {
       // Calculate width between pointers
       int width = right - left;
       // Calculate area using the smaller height
       maxArea = Math.max(maxArea, width * 
               Math.min(height[left], height[right]));
       
       // Move the pointer with smaller height
       if (height[left] < height[right]) {
           left++;
       } else {
           right--;
       }
   }
   
   return maxArea;
}