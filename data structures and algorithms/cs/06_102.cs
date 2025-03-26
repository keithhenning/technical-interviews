public static int FindMissingNumber(int[] nums)
{
   int n = nums.Length;
   int expectedSum = n * (n + 1) / 2;
   int actualSum = 0;
   foreach (int num in nums)
   {
      actualSum += num;
   }
   return expectedSum - actualSum;
}

// Alternative bit manipulation approach
public static int FindMissingNumberXor(int[] nums)
{
   int result = nums.Length;
   for (int i = 0; i < nums.Length; i++)
   {
      result ^= i ^ nums[i];
   }
   return result;
}