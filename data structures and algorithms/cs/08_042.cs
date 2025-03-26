public class MinimumFinder
{
   public static int FindMinimum(int[] nums)
   {
      int left = 0;
      int right = nums.Length - 1;

      if (nums[left] <= nums[right])
      {
         return nums[left];
      }

      while (left < right)
      {
         int mid = left + (right - left) / 2;

         if (nums[mid] > nums[right])
         {
            left = mid + 1;
         }
         else
         {
            right = mid;
         }
      }

      return nums[left];
   }
}