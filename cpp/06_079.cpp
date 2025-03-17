#include <iostream>
#include <vector>

/**
 * Build a prefix sum array from the input array.
 * 
 * @param arr The input array
 * @return The prefix sum array
 */
std::vector<int> buildPrefixSum(const std::vector<int>& arr) {
    int n = arr.size();
    std::vector<int> prefixSum(n);
    prefixSum[0] = arr[0];
    
    for (int i = 1; i < n; i++) {
        prefixSum[i] = prefixSum[i-1] + arr[i];
    }
    
    return prefixSum;
}

/**
 * Calculate the sum of elements from index i to j (inclusive).
 * 
 * @param prefixSum The prefix sum array
 * @param i Start index
 * @param j End index
 * @return Sum of elements from index i to j
 */
int rangeSum(const std::vector<int>& prefixSum, int i, int j) {
    if (i == 0) {
        return prefixSum[j];
    } else {
        return prefixSum[j] - prefixSum[i-1];
    }
}

int main() {
    std::vector<int> arr = {3, 1, 4, 1, 5, 9, 2, 6};
    std::vector<int> prefix = buildPrefixSum(arr);
    
    std::cout << "Original array: ";
    for (int num : arr) {
        std::cout << num << " ";
    }
    std::cout << std::endl;
    
    std::cout << "Prefix sum array: ";
    for (int num : prefix) {
        std::cout << num << " ";
    }
    std::cout << std::endl;
    
    std::cout << "Sum of elements from index 2 to 5: " << rangeSum(prefix, 2, 5) << std::endl;
    
    return 0;
}