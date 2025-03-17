#include <vector>
#include <climits>
#include <algorithm>

class Solution {
public:
    int minMaxGroupSum(std::vector<int>& nums, int k) {
        int left = INT_MIN;
        int right = 0;
        
        // Calculate the search boundaries
        for (int num : nums) {
            left = std::max(left, num);
            right += num;
        }
        
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (canSplit(nums, k, mid)) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
    
private:
    bool canSplit(const std::vector<int>& nums, int k, 
                 int threshold) {
        int groups = 1;
        int currentSum = 0;
        
        for (int num : nums) {
            // If a single element exceeds threshold,
            // splitting is impossible
            if (num > threshold) {
                return false;
            }
            
            // Try adding the current number to current group
            if (currentSum + num <= threshold) {
                currentSum += num;
            } else {
                // Start a new group
                groups++;
                currentSum = num;
                
                // If we need more than k groups, return false
                if (groups > k) {
                    return false;
                }
            }
        }
        
        return true;
    }
};