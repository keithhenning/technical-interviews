#include <vector>
#include <algorithm>

int maxViewingArea(std::vector<int>& heights) {
    int left = 0;
    int right = heights.size() - 1;
    int maxArea = 0;
    
    while (left < right) {
        int width = right - left;
        int height = std::min(heights[left], heights[right]);
        maxArea = std::max(maxArea, width * height);
        
        if (heights[left] < heights[right]) {
            left++;
        } else {
            right--;
        }
    }
    
    return maxArea;
}