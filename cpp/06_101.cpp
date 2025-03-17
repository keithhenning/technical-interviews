int findMissingNumber(const std::vector<int>& nums) {
    int n = nums.size();
    int expectedSum = n * (n + 1) / 2;
    int actualSum = 0;
    for (int num : nums) {
        actualSum += num;
    }
    return expectedSum - actualSum;
}

// Alternative bit manipulation approach
int findMissingNumberXor(const std::vector<int>& nums) {
    int result = nums.size();
    for (int i = 0; i < nums.size(); i++) {
        result ^= i ^ nums[i];
    }
    return result;
}