#include <vector>
#include <algorithm>
#include <climits>
using namespace std;

class Solution {
public:
    // Find the kth element in two sorted arrays
    int findKthElement(vector<int>& nums1, vector<int>& nums2, 
                      int k) {
        // Ensure nums1 is the smaller array
        if (nums1.size() > nums2.size()) {
            return findKthElement(nums2, nums1, k);
        }
        
        int m = nums1.size();
        int n = nums2.size();
        // Set binary search bounds
        int left = max(0, k - n);
        int right = min(k, m);
        
        // Binary search
        while (left <= right) {
            int mid1 = (left + right) / 2;
            int mid2 = k - mid1;
            
            // Get boundary elements
            int l1 = (mid1 == 0) ? INT_MIN : nums1[mid1 - 1];
            int r1 = (mid1 == m) ? INT_MAX : nums1[mid1];
            int l2 = (mid2 == 0) ? INT_MIN : nums2[mid2 - 1];
            int r2 = (mid2 == n) ? INT_MAX : nums2[mid2];
            
            // Check if partition is correct
            if (l1 <= r2 && l2 <= r1) {
                return max(l1, l2);
            } 
            // Adjust search boundaries
            else if (l1 > r2) {
                right = mid1 - 1;
            } 
            else {
                left = mid1 + 1;
            }
        }
        
        // Should not reach here if arrays are sorted
        return -1;
    }
};