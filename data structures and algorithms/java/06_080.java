import java.util.Arrays;

public class PrefixSum {
  /**
   * Build a prefix sum array from input array
   */
  public static int[] buildPrefixSum(int[] arr) {
     int n = arr.length;
     int[] prefixSum = new int[n];
     prefixSum[0] = arr[0];
     
     for (int i = 1; i < n; i++) {
        prefixSum[i] = prefixSum[i-1] + arr[i];
     }
     
     return prefixSum;
  }
  
  /**
   * Calculate sum of elements from index i to j inclusive
   */
  public static int rangeSum(int[] prefixSum, int i, int j) {
     if (i == 0) {
        return prefixSum[j];
     } else {
        return prefixSum[j] - prefixSum[i-1];
     }
  }
  
  public static void main(String[] args) {
     int[] arr = {3, 1, 4, 1, 5, 9, 2, 6};
     int[] prefix = buildPrefixSum(arr);
     
     System.out.println("Original array: " + 
        Arrays.toString(arr));
     System.out.println("Prefix sum array: " + 
        Arrays.toString(prefix));
     System.out.println("Sum of elements from index 2 to 5: " + 
        rangeSum(prefix, 2, 5));
  }
}