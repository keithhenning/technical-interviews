#include <vector>

int trapRainwater(std::vector<int>& heights) {
    if (heights.size() < 3) {
        return 0;
    }
    
    int left = 0, right = heights.size() - 1;
    int leftMax = heights[left];
    int rightMax = heights[right];
    int totalWater = 0;
    
    while (left < right) {
        if (heights[left] < heights[right]) {
            left++;
            if (heights[left] < leftMax) {
                totalWater += leftMax - heights[left];
            } else {
                leftMax = heights[left];
            }
        } else {
            right--;
            if (heights[right] < rightMax) {
                totalWater += rightMax - heights[right];
            } else {
                rightMax = heights[right];
            }
        }
    }
    
    return totalWater;
}