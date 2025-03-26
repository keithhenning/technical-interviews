public static int CountBitsToFlip(int a, int b)
{
   // XOR gives 1 for bits that are different
   int xorResult = a ^ b;
   // Count the set bits in the XOR result
   return CountSetBits(xorResult);
}