public static int MaxSubarrayXor(int[] nums)
{
   if (nums == null || nums.Length == 0)
   {
      return 0;
   }

   int maxXor = int.MinValue;
   int prefixXor = 0;

   foreach (int num in nums)
   {
      prefixXor ^= num;
      maxXor = Math.Max(maxXor, prefixXor);

      int currXor = prefixXor;
      for (int i = 0; i < nums.Length; i++)
      {
         currXor ^= nums[i];
         maxXor = Math.Max(maxXor, currXor);
      }
   }

   return maxXor;
}