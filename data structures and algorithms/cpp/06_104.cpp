#include <vector>
#include <algorithm>

int maxSubarrayXor(const std::vector<int>& nums) {
    if (nums.empty()) {
        return 0;
    }

    int maxXor = INT_MIN;
    int prefixXor = 0;

    for (int num : nums) {
        prefixXor ^= num;
        maxXor = std::max(maxXor, prefixXor);

        int currXor = prefixXor;
        for (size_t i = 0; i < nums.size(); ++i) {
            currXor ^= nums[i];
            maxXor = std::max(maxXor, currXor);
        }
    }

    return maxXor;
}