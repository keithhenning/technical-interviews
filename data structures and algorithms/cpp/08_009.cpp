#include <iostream>
#include <vector>
#include <unordered_map>

std::vector<int> twoSum(std::vector<int>& nums, int target) {
    std::unordered_map<int, int> numMap;  // value -> index
    
    for (int i = 0; i < nums.size(); i++) {
        int complement = target - nums[i];
        
        if (numMap.find(complement) != numMap.end()) {
            return {numMap[complement], i};
        }
        
        numMap[nums[i]] = i;
    }
    
    return {};  // No solution found
}

int main() {
    std::vector<int> nums1 = {2, 7, 11, 15};
    std::vector<int> result1 = twoSum(nums1, 9);
    std::cout << "[" << result1[0] << ", " << result1[1] << "]" 
              << std::endl;  // [0, 1]
    
    std::vector<int> nums2 = {3, 2, 4};
    std::vector<int> result2 = twoSum(nums2, 6);
    std::cout << "[" << result2[0] << ", " << result2[1] << "]" 
              << std::endl;  // [1, 2]
    
    return 0;
}