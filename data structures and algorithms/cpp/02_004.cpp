#include <iostream>
#include <vector>
#include <algorithm>

// Function to merge overlapping intervals
std::vector<std::vector<int>> merge(
   std::vector<std::vector<int>>& intervals) {
   // Handle empty input case
   if (intervals.empty()) {
       return {};
   }
   
   // Sort intervals by start time to ensure proper merging
   std::sort(intervals.begin(), intervals.end(), 
             [](const std::vector<int>& a, 
                const std::vector<int>& b) {
                 return a[0] < b[0];
             });
   
   // Initialize result with first interval
   std::vector<std::vector<int>> result;
   result.push_back(intervals[0]);
   
   // Iterate through remaining intervals
   for (size_t i = 1; i < intervals.size(); i++) {
       std::vector<int>& current = intervals[i];
       std::vector<int>& lastMerged = result.back();
       
       // Check if current interval overlaps with last merged
       if (current[0] <= lastMerged[1]) {
           // Merge overlapping intervals by updating end time
           lastMerged[1] = std::max(lastMerged[1], current[1]);
       } else {
           // If no overlap, add current interval to result
           result.push_back(current);
       }
   }
   
   return result;
}

// Test function to verify merge implementation
void testMergeCpp() {
   // Test case with overlapping and non-overlapping intervals
   std::vector<std::vector<int>> intervals = {
       {1, 3}, {2, 6}, {8, 10}, {15, 18}
   };
   std::vector<std::vector<int>> result = merge(intervals);
   
   std::cout << "C++ Result: [";
   for (size_t i = 0; i < result.size(); i++) {
       std::cout << "[" << result[i][0] << "," 
                 << result[i][1] << "]";
       if (i < result.size() - 1) {
           std::cout << ", ";
       }
   }
   std::cout << "]" << std::endl;
   // Expected output: [[1,6],[8,10],[15,18]]
}

int main() {
   testMergeCpp();
   return 0;
}