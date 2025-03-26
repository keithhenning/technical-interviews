public static int RangeBitwiseAnd(int m, int n)
{
   // Count the number of shifts needed to make m and n equal
   int shift = 0;
   while (m < n)
   {
      m >>= 1;
      n >>= 1;
      shift++;
   }

   // Shift back to get the common prefix
   return m << shift;
}