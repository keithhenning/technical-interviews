using System;
using System.Linq;

public class PrefixSum {
    /**
     * Build a prefix sum array from input array
     */
    public static int[] BuildPrefixSum(int[] arr) {
        int n = arr.Length;
        int[] prefixSum = new int[n];
        prefixSum[0] = arr[0];

        for (int i = 1; i < n; i++) {
            prefixSum[i] = prefixSum[i - 1] + arr[i];
        }

        return prefixSum;
    }

    /**
     * Calculate sum of elements from index i to j inclusive
     */
    public static int RangeSum(int[] prefixSum, int i, int j) {
        if (i == 0) {
            return prefixSum[j];
        } else {
            return prefixSum[j] - prefixSum[i - 1];
        }
    }

    public static void Main(string[] args) {
        int[] arr = { 3, 1, 4, 1, 5, 9, 2, 6 };
        int[] prefix = BuildPrefixSum(arr);

        Console.WriteLine("Original array: " + string.Join(", ", arr));
        Console.WriteLine("Prefix sum array: " + string.Join(", ", prefix));
        Console.WriteLine("Sum of elements from index 2 to 5: " + RangeSum(prefix, 2, 5));
    }
}