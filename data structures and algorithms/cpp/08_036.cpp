#include <unordered_map>
#include <vector>

bool hasFrequencyThreshold(std::vector<int>& nums, int k) {
    std::unordered_map<int, int> counter;
    
    for (int num : nums) {
        counter[num]++;
        if (counter[num] >= k) {
            return true;
        }
    }
    
    return false;
}