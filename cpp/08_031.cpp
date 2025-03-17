#include <unordered_set>
#include <vector>

bool hasNearbyDuplicates(std::vector<int>& nums, int k) {
    std::unordered_set<int> window;
    
    for (int i = 0; i < nums.size(); i++) {
        if (i >= k) {
            window.erase(nums[i - k]);
        }
        
        if (window.count(nums[i]) > 0) {
            return true;
        }
        
        window.insert(nums[i]);
    }
    
    return false;
}