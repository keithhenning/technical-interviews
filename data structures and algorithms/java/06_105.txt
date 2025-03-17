public static int maxSubarrayXor(int[] nums) {
   if (nums == null || nums.length == 0) {
       return 0;
   }
   
   int maxXor = Integer.MIN_VALUE;
   int prefixXor = 0;
   
   for (int num : nums) {
       prefixXor ^= num;
       maxXor = Math.max(maxXor, prefixXor);
       
       int currXor = prefixXor;
       for (int i = 0; i < nums.length; i++) {
           currXor ^= nums[i];
           maxXor = Math.max(maxXor, currXor);
       }
   }
   
   return maxXor;
}