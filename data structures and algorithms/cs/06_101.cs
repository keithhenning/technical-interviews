/**
 * Flip bits from position i to j
 */
public static int FlipBitsInRange(int n, int i, int j) {
    // Create mask with 1s from position i to j
    int mask = ((1 << (j - i + 1)) - 1) << i;
    return n ^ mask;
}