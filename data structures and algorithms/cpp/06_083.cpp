#include <iostream>
#include <vector>
#include <algorithm>

int trap(const std::vector<int>& height) {
    if (height.empty()) {
        return 0;
    }
    
    int n = height.size();
    std::vector<int> leftMax(n);
    std::vector<int> rightMax(n);
    
    // Fill leftMax
    leftMax[0] = height[0];
    for (int i = 1; i < n; i++) {
        leftMax[i] = std::max(leftMax[i-1], height[i]);
    }
    
    // Fill rightMax
    rightMax[n-1] = height[n-1];
    for (int i = n-2; i >= 0; i--) {
        rightMax[i] = std::max(rightMax[i+1], height[i]);
    }
    
    // Calculate trapped water
    int water = 0;
    for (int i = 0; i < n; i++) {
        water += std::min(leftMax[i], rightMax[i]) - height[i];
    }
    
    return water;
}

int main() {
    std::vector<int> height = {0,1,0,2,1,0,1,3,2,1,2,1};
    std::cout << trap(height) << std::endl;  // Output: 6
    
    return 0;
}