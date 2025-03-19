using System;

public class BinaryManipulation {
    public static void Main(string[] args) {
        int a = 25;  // 11001 in binary
        int b = 13;  // 01101 in binary

        // Print binary representations and operations
        Console.WriteLine("a = " + a + " (binary: " + Convert.ToString(a, 2) + ")");
        Console.WriteLine("b = " + b + " (binary: " + Convert.ToString(b, 2) + ")");
        Console.WriteLine("a & b = " + (a & b) + " (binary: " + Convert.ToString(a & b, 2) + ")");  // AND: 9
        Console.WriteLine("a | b = " + (a | b) + " (binary: " + Convert.ToString(a | b, 2) + ")");  // OR: 29
        Console.WriteLine("a ^ b = " + (a ^ b) + " (binary: " + Convert.ToString(a ^ b, 2) + ")");  // XOR: 20
        Console.WriteLine("~a = " + (~a) + " (binary: " + Convert.ToString(~a, 2) + ")");  // NOT: -26
        Console.WriteLine("a << 2 = " + (a << 2) + " (binary: " + Convert.ToString(a << 2, 2) + ")");  // Left: 100
        Console.WriteLine("a >> 2 = " + (a >> 2) + " (binary: " + Convert.ToString(a >> 2, 2) + ")");  // Right: 6
    }

    /**
     * Count 1 bits in binary representation
     */
    public static int CountSetBits(int n) {
        int count = 0;
        while (n != 0) {
            count += n & 1;  // Check least significant bit
            n >>>= 1;        // Unsigned right shift
        }
        return count;
    }

    /**
     * Count set bits using C#'s built-in function
     */
    public static int CountSetBitsBuiltIn(int n) {
        return BitOperations.PopCount((uint)n);
    }

    /**
     * Check if n is a power of 2
     */
    public static bool IsPowerOfTwo(int n) {
        return n > 0 && (n & (n - 1)) == 0;
    }

    /**
     * Set bit at given position to 1
     */
    public static int SetBit(int n, int position) {
        return n | (1 << position);
    }

    /**
     * Clear bit at given position to 0
     */
    public static int ClearBit(int n, int position) {
        return n & ~(1 << position);
    }

    /**
     * Toggle bit at given position
     */
    public static int ToggleBit(int n, int position) {
        return n ^ (1 << position);
    }

    /**
     * Check if bit at position is set
     */
    public static bool IsBitSet(int n, int position) {
        return (n & (1 << position)) != 0;
    }

    /**
     * Find single number in array with all others appearing twice
     */
    public static int FindSingleNumber(int[] nums) {
        int result = 0;
        foreach (int num in nums) {
            result ^= num;  // XOR of duplicates is 0
        }
        return result;
    }
}