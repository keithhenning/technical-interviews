public int maxViewingArea(int[] heights) {
    int left = 0;
    int right = heights.length - 1;
    int maxArea = 0;
    
    while (left < right) {
        int width = right - left;
        int height = Math.min(heights[left], heights[right]);
        maxArea = Math.max(maxArea, width * height);
        
        if (heights[left] < heights[right]) {
            left++;
        } else {
            right--;
        }
    }
    
    return maxArea;
}