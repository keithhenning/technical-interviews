using System;
using System.Collections.Generic;

public class SlidingWindow {
    /**
     * Find maximum sum subarray of size k
     */
    public int MaxSumSubarray(List<int> arr, int k) {
        // Validate input
        if (arr == null || arr.Count < k) {
            return -1;
        }

        // Calculate initial window sum
        int windowSum = 0;
        for (int i = 0; i < k; i++) {
            windowSum += arr[i];
        }
        int maxSum = windowSum;

        // Slide window through array
        for (int i = k; i < arr.Count; i++) {
            // Add new element and remove oldest element
            windowSum = windowSum + arr[i] - arr[i - k];
            // Update maximum sum
            maxSum = Math.Max(maxSum, windowSum);
        }

        return maxSum;
    }

    /**
     * Test sliding window algorithm
     */
    public void TestSlidingWindow() {
        // Test case 1: Basic case
        List<int> arr1 = new List<int> {1, 4, 2, 10, 2, 3, 1, 0, 20};
        int k1 = 4;
        Console.WriteLine("Test 1: Window size " + k1);
        Console.WriteLine("Array: " + string.Join(", ", arr1));
        Console.WriteLine("Expected: 24 (sum of [2, 3, 1, 0])");
        Console.WriteLine("Result: " + MaxSumSubarray(arr1, k1) + "\n");

        // Test case 2: Window equals array size
        List<int> arr2 = new List<int> {1, 4, 2, 10};
        int k2 = 4;
        Console.WriteLine("Test 2: Window equals array size");
        Console.WriteLine("Array: " + string.Join(", ", arr2));
        Console.WriteLine("Expected: 17");
        Console.WriteLine("Result: " + MaxSumSubarray(arr2, k2) + "\n");

        // Test case 3: Array smaller than window
        List<int> arr3 = new List<int> {1, 2};
        int k3 = 3;
        Console.WriteLine("Test 3: Array smaller than window");
        Console.WriteLine("Array: " + string.Join(", ", arr3));
        Console.WriteLine("Expected: -1");
        Console.WriteLine("Result: " + MaxSumSubarray(arr3, k3) + "\n");
    }

    /**
     * Main method to run tests
     */
    public static void Main(string[] args) {
        SlidingWindow sw = new SlidingWindow();
        sw.TestSlidingWindow();
    }
}