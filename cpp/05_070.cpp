class Solution {
public:
   // Find two numbers that add up to target
   std::vector<int> twoSum(std::vector<int>& nums, 
                          int target) {
      // Map to store previously seen numbers and indices
      std::unordered_map<int, int> seen;  // num -> index
      
      // Check each number in the array
      for (int i = 0; i < nums.size(); i++) {
         // Calculate the complement needed
         int complement = target - nums[i];
         
         // If complement exists, return both indices
         if (seen.find(complement) != seen.end()) {
            return {seen[complement], i};
         }
         
         // Store current number and its index
         seen[nums[i]] = i;
      }
      
      // No solution found
      return {};
   }
};