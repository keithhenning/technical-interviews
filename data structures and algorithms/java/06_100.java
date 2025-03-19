/**
* Check if n is one less than a power of 2
*/
public static boolean isOneLessThanPowerOfTwo(int n) {
   return n > 0 && (n & (n + 1)) == 0;
}