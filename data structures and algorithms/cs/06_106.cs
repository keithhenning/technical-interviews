public static int AddWithoutPlus(int a, int b) {
   while (b != 0) {
       // Carry is AND, shifted by 1
       int carry = (a & b) << 1;
       // Sum is XOR
       a = a ^ b;
       b = carry;
   }
   return a;
}