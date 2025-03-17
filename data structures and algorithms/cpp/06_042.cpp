std::vector<int> findTwoSum(const std::vector<int>& numbers, 
                     int target) {
    int left = 0;
    int right = numbers.size() - 1;
    
    while (left < right) {
        int currentSum = numbers[left] + numbers[right];
        if (currentSum == target) {
            // 1-based indexing
            return {left + 1, right + 1};
        } else if (currentSum < target) {
            left++;
        } else {
            right--;
        }
    }
    
    // No solution found
    return {};
}