public static int findMissingNumber(int[] nums) {
   int n = nums.length;
   int expectedSum = n * (n + 1) / 2;
   int actualSum = 0;
   for (int num : nums) {
       actualSum += num;
   }
   return expectedSum - actualSum;
}

// Alternative bit manipulation approach
public static int findMissingNumberXor(int[] nums) {
   int result = nums.length;
   for (int i = 0; i < nums.length; i++) {
       result ^= i ^ nums[i];
   }
   return result;
}