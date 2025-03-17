#include <vector>
#include <climits>
#include <algorithm>

class Solution {
public:
    int kthAncestralElement(std::vector<std::vector<int>>& arrays, 
                           int k) {
        // Define boundaries for binary search
        int left = INT_MAX;
        int right = INT_MIN;
        
        for (const auto& array : arrays) {
            if (!array.empty()) {
                left = std::min(left, array[0]);
                right = std::max(right, array.back());
            }
        }
        
        while (left < right) {
            int mid = left + (right - left) / 2;
            
            // Count ancestral elements less than or equal to mid
            int count = 0;
            for (const auto& array : arrays) {
            // Binary search to find position of 1st element > mid
                count += binarySearch(array, mid);
            }
            
            if (count < k) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        
        return left;
    }
    
private:
    int binarySearch(const std::vector<int>& array, int target) {
        int left = 0, right = array.size();
        
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (array[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        
        return left;  // Returns the count of elements <= target
    }
};