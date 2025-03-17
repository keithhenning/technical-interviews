#include <iostream>
#include <vector>
#include <stack>

std::vector<int> nextGreaterElement(
        const std::vector<int>& nums) {
    int n = nums.size();
    std::vector<int> result(n, -1);  // Initialize with -1
    std::stack<int> stack;
    
    for (int i = 0; i < n; i++) {
        // Maintain monotonic property
        while (!stack.empty() && nums[i] > nums[stack.top()]) {
            int popped = stack.top();
            stack.pop();
            result[popped] = nums[i];
        }
        
        stack.push(i);
    }
    
    return result;
}

int main() {
    std::vector<int> nums = {4, 5, 2, 10, 8};
    std::vector<int> result = nextGreaterElement(nums);
    
    for (int val : result) {
        std::cout << val << " ";
    }
    // Output: 5 10 10 -1 -1
    
    return 0;
}