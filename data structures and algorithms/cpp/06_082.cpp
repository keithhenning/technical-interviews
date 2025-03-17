#include <iostream>
#include <vector>
#include <stack>
#include <algorithm>

int largestRectangleArea(const std::vector<int>& heights) {
    std::stack<int> stack;
    int maxArea = 0;
    int i = 0;
    
    while (i < heights.size()) {
        // If stack is empty or current height is larger than 
        // stack top
        if (stack.empty() || 
            heights[stack.top()] <= heights[i]) {
            stack.push(i);
            i++;
        } else {
            // Calculate area with stack top as smallest bar
            int top = stack.top();
            stack.pop();
            
            // Calculate width
            int width = stack.empty() ? i : i - stack.top() - 1;
            
            // Update max area
            maxArea = std::max(maxArea, heights[top] * width);
        }
    }
    
    // Process remaining elements in stack
    while (!stack.empty()) {
        int top = stack.top();
        stack.pop();
        int width = stack.empty() ? i : i - stack.top() - 1;
        maxArea = std::max(maxArea, heights[top] * width);
    }
    
    return maxArea;
}

int main() {
    std::vector<int> heights = {2, 1, 5, 6, 2, 3};
    std::cout << largestRectangleArea(heights) << std::endl;
    // Output: 10
    
    return 0;
}