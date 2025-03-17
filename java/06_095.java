public class BinaryManipulation {
   
   public static void main(String[] args) {
      int a = 25;  // 11001 in binary
      int b = 13;  // 01101 in binary
      
      // Print binary representations and operations
      System.out.println("a = " + a + " (binary: " + 
         Integer.toBinaryString(a) + ")");
      System.out.println("b = " + b + " (binary: " + 
         Integer.toBinaryString(b) + ")");
      System.out.println("a & b = " + (a & b) + " (binary: " + 
         Integer.toBinaryString(a & b) + ")");  // AND: 9
      System.out.println("a | b = " + (a | b) + " (binary: " + 
         Integer.toBinaryString(a | b) + ")");  // OR: 29
      System.out.println("a ^ b = " + (a ^ b) + " (binary: " + 
         Integer.toBinaryString(a ^ b) + ")");  // XOR: 20
      System.out.println("~a = " + (~a) + " (binary: " + 
         Integer.toBinaryString(~a) + ")");  // NOT: -26
      System.out.println("a << 2 = " + (a << 2) + " (binary: " + 
         Integer.toBinaryString(a << 2) + ")");  // Left: 100
      System.out.println("a >> 2 = " + (a >> 2) + " (binary: " + 
         Integer.toBinaryString(a >> 2) + ")");  // Right: 6
   }
   
   /**
    * Count 1 bits in binary representation
    */
   public static int countSetBits(int n) {
      int count = 0;
      while (n != 0) {
         count += n & 1;  // Check least significant bit
         n >>>= 1;        // Unsigned right shift
      }
      return count;
   }
   
   /**
    * Count set bits using Java's built-in function
    */
   public static int countSetBitsBuiltIn(int n) {
      return Integer.bitCount(n);
   }
   
   /**
    * Check if n is a power of 2
    */
   public static boolean isPowerOfTwo(int n) {
      return n > 0 && (n & (n - 1)) == 0;
   }
   
   /**
    * Set bit at given position to 1
    */
   public static int setBit(int n, int position) {
      return n | (1 << position);
   }
   
   /**
    * Clear bit at given position to 0
    */
   public static int clearBit(int n, int position) {
      return n & ~(1 << position);
   }
   
   /**
    * Toggle bit at given position
    */
   public static int toggleBit(int n, int position) {
      return n ^ (1 << position);
   }
   
   /**
    * Check if bit at position is set
    */
   public static boolean isBitSet(int n, int position) {
      return (n & (1 << position)) != 0;
   }
   
   /**
    * Find single number in array with all others appearing twice
    */
   public static int findSingleNumber(int[] nums) {
      int result = 0;
      for (int num : nums) {
         result ^= num;  // XOR of duplicates is 0
      }
      return result;
   }
}