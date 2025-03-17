public static int[] findTwoSingleNumbers(int[] nums) {
   // Get XOR of all numbers
   int xorAll = 0;
   for (int num : nums) {
       xorAll ^= num;
   }
   
   // Find a bit where the two unique numbers differ
   // (rightmost set bit)
   int diffBit = xorAll & -xorAll;
   
   // Separate numbers into two groups based on the diff bit
   int num1 = 0;
   for (int num : nums) {
       if ((num & diffBit) != 0) {
           num1 ^= num;
       }
   }
   
   // The other number is XOR of num1 and xorAll
   int num2 = xorAll ^ num1;
   
   return new int[]{num1, num2};
}