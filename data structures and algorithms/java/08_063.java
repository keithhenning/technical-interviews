public class Solution {
   public int findKthElement(int[] nums1, 
         int[] nums2, int k) {
      // Ensure nums1 is smaller array
      if (nums1.length > nums2.length) {
         return findKthElement(nums2, nums1, k);
      }
      
      int m = nums1.length;
      int n = nums2.length;
      int left = Math.max(0, k - n);
      int right = Math.min(k, m);
      
      while (left <= right) {
         int mid1 = (left + right) / 2;
         int mid2 = k - mid1;
         
         // Get boundary elements
         int l1 = (mid1 == 0) ? 
            Integer.MIN_VALUE : nums1[mid1 - 1];
         int r1 = (mid1 == m) ? 
            Integer.MAX_VALUE : nums1[mid1];
         int l2 = (mid2 == 0) ? 
            Integer.MIN_VALUE : nums2[mid2 - 1];
         int r2 = (mid2 == n) ? 
            Integer.MAX_VALUE : nums2[mid2];
         
         // Check partition condition
         if (l1 <= r2 && l2 <= r1) {
            return Math.max(l1, l2);
         } else if (l1 > r2) {
            right = mid1 - 1;
         } else {
            left = mid1 + 1;
         }
      }
      
      // Invalid input
      return -1;
   }
}