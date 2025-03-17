#include <iostream>
#include <vector>

std::vector<int> queryRotatedArray(
        const std::vector<int>& arr,
        const std::vector<std::vector<int>>& queries) {
    int n = arr.size();
    std::vector<int> results;
    
    for (const auto& query : queries) {
        int rotation = query[0];
        int index = query[1];
        
        // Calculate the effective rotation
        int effectiveRotation = rotation % n;
        
        // Calculate the original position
        // Add n before modulo to handle negative numbers
        int originalPosition = 
            (index - effectiveRotation + n) % n;
        results.push_back(arr[originalPosition]);
    }
    
    return results;
}

int main() {
    std::vector<int> arr = {3, 7, 1, 9, 5};
    std::vector<std::vector<int>> queries = 
        {{2, 1}, {4, 3}, {0, 2}};
    
    std::vector<int> results = 
        queryRotatedArray(arr, queries);
    
    // Print results
    std::cout << "[";
    for (size_t i = 0; i < results.size(); ++i) {
        std::cout << results[i];
        if (i < results.size() - 1) {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl; // Output: [3, 3, 1]
    
    return 0;
}