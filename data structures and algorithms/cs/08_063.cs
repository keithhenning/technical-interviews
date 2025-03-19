public class Solution 
{
   public int FindKthElement(
      int[] nums1, 
      int[] nums2, 
      int k) 
   {
      if (nums1.Length > nums2.Length) 
      {
         return FindKthElement(nums2, nums1, k);
      }

      int m = nums1.Length;
      int n = nums2.Length;
      int left = Math.Max(0, k - n);
      int right = Math.Min(k, m);

      while (left <= right) 
      {
         int mid1 = (left + right) / 2;
         int mid2 = k - mid1;

         int l1 = (mid1 == 0) ? 
            int.MinValue : nums1[mid1 - 1];
         int r1 = (mid1 == m) ? 
            int.MaxValue : nums1[mid1];
         int l2 = (mid2 == 0) ? 
            int.MinValue : nums2[mid2 - 1];
         int r2 = (mid2 == n) ? 
            int.MaxValue : nums2[mid2];

         if (l1 <= r2 && l2 <= r1) 
         {
            return Math.Max(l1, l2);
         } 
         else if (l1 > r2) 
         {
            right = mid1 - 1;
         } 
         else 
         {
            left = mid1 + 1;
         }
      }

      return -1;
   }
}