#include <iostream>
#include <vector>
#include <unordered_map>
#include <algorithm>

int maxSubarrayWithTargetSum(
    const std::vector<int>& nums, 
    int target
) {
    // Map to store the first occurrence of each sum
    std::unordered_map<int, int> sumIndexMap;
    sumIndexMap[0] = -1; // Initialize with 0 at index -1
    
    int maxLength = 0;
    int currentSum = 0;
    
    for (int i = 0; i < nums.size(); i++) {
        currentSum += nums[i];
        
        // Check if we can form a subarray with sum = target
        if (sumIndexMap.find(currentSum - target) != 
            sumIndexMap.end()) {
            int subarrayStart = sumIndexMap[currentSum - target] + 1;
            int currentLength = i - subarrayStart + 1;
            maxLength = std::max(maxLength, currentLength);
        }
        
        // Only store the first occurrence of each sum
        if (sumIndexMap.find(currentSum) == 
            sumIndexMap.end()) {
            sumIndexMap[currentSum] = i;
        }
    }
    
    return maxLength;
}

int main() {
    std::vector<int> nums = {1, -1, 5, -2, 3, 0, 2, -4, 1};
    int target = 3;
    std::cout << maxSubarrayWithTargetSum(nums, target) 
              << std::endl; // Output: 4
    return 0;
}