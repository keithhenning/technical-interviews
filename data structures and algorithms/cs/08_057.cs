public class Solution 
{
   public int MinMaxGroupSum(int[] nums, int k) 
   {
      int left = int.MinValue;
      int right = 0;

      foreach (var num in nums) 
      {
         left = Math.Max(left, num);
         right += num;
      }

      while (left < right) 
      {
         int mid = left + (right - left) / 2;
         if (CanSplit(nums, k, mid)) 
         {
            right = mid;
         } 
         else 
         {
            left = mid + 1;
         }
      }

      return left;
   }

   private bool CanSplit(
      int[] nums, 
      int k, 
      int threshold) 
   {
      int groups = 1;
      int currentSum = 0;

      foreach (var num in nums) 
      {
         if (num > threshold) 
         {
            return false;
         }

         if (currentSum + num <= threshold) 
         {
            currentSum += num;
         } 
         else 
         {
            groups++;
            currentSum = num;

            if (groups > k) 
            {
               return false;
            }
         }
      }

      return true;
   }
}