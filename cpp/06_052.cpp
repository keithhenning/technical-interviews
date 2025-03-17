/**
 * Test first window
 */
std::vector<int> testBoundaries(const std::vector<int>& arr, int k) {
    /**
     * Test first window
     */
    std::vector<int> firstWindowArr(arr.begin(), arr.begin() + k);
    int firstWindow = maxSumSubarray(firstWindowArr, k);
    
    /**
     * Test last window
     */
    std::vector<int> lastWindowArr(arr.end() - k, arr.end());
    int lastWindow = maxSumSubarray(lastWindowArr, k);
    
    return {firstWindow, lastWindow};
}