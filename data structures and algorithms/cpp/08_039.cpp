#include <vector>
#include <stack>
#include <algorithm>

int maxProductivityZone(std::vector<int>& capacities) {
    std::stack<int> stack;
    int maxArea = 0;
    int n = capacities.size();
    
    for (int i = 0; i < n; i++) {
        // Process stations with higher capacity than current
        while (!stack.empty() && 
               capacities[stack.top()] > capacities[i]) {
            int height = capacities[stack.top()];
            stack.pop();
            int width = stack.empty() ? i : 
                        i - stack.top() - 1;
            maxArea = std::max(maxArea, height * width);
        }
        
        stack.push(i);
    }
    
    // Process remaining stations in stack
    while (!stack.empty()) {
        int height = capacities[stack.top()];
        stack.pop();
        int width = stack.empty() ? n : 
                    n - stack.top() - 1;
        maxArea = std::max(maxArea, height * width);
    }
    
    return maxArea;
}