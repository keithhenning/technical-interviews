using System;
using System.Collections.Generic;

public class MaximumSubarrayWithTargetSum
{
   public static int MaxSubarrayWithTargetSum(
      int[] nums,
      int target)
   {
      var sumIndexMap = new Dictionary<int, int>
      {
         { 0, -1 }
      };
      int maxLength = 0;
      int currentSum = 0;

      for (int i = 0; i < nums.Length; i++)
      {
         currentSum += nums[i];

         if (sumIndexMap.ContainsKey(currentSum - target))
         {
            int subarrayStart =
               sumIndexMap[currentSum - target] + 1;
            int currentLength = i - subarrayStart + 1;
            maxLength = Math.Max(maxLength, currentLength);
         }

         if (!sumIndexMap.ContainsKey(currentSum))
         {
            sumIndexMap[currentSum] = i;
         }
      }

      return maxLength;
   }

   public static void Main(string[] args)
   {
      int[] nums =
         { 1, -1, 5, -2, 3, 0, 2, -4, 1 };
      int target = 3;
      int result =
         MaxSubarrayWithTargetSum(nums, target);
      Console.WriteLine(
         "Maximum subarray length: " + result);
   }
}