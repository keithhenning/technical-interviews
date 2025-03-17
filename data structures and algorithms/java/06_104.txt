public static boolean isPowerOfFour(int n) {
    // Must be positive and a power of 2
    if (n <= 0 || (n & (n-1)) != 0) {
        return false;
    }
    // Power of 4 has set bit at even positions (0-indexed)
    // So check if set bit position is even by ANDing with 0x55555555
    // (which is 01010101...01 in binary)
    return (n & 0x55555555) != 0;
}