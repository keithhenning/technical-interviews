int maxArea(const std::vector<int>& height) {
    int left = 0;
    int right = height.size() - 1;
    int maxArea = 0;
    
    while (left < right) {
        // Calculate width between pointers
        int width = right - left;
        // Calculate area using the smaller height
        maxArea = std::max(maxArea, width * 
                std::min(height[left], height[right]));
        
        // Move the pointer with smaller height
        if (height[left] < height[right]) {
            left++;
        } else {
            right--;
        }
    }
    
    return maxArea;
}