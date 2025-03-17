import java.util.Arrays;
import java.util.List;

public class SlidingWindow {
   /**
    * Find maximum sum subarray of size k
    */
   public int maxSumSubarray(List<Integer> arr, int k) {
      // Validate input
      if (arr == null || arr.size() < k) {
         return -1;
      }
      
      // Calculate initial window sum
      int windowSum = 0;
      for (int i = 0; i < k; i++) {
         windowSum += arr.get(i);
      }
      int maxSum = windowSum;
      
      // Slide window through array
      for (int i = k; i < arr.size(); i++) {
         // Add new element and remove oldest element
         windowSum = windowSum + arr.get(i) - arr.get(i - k);
         // Update maximum sum
         maxSum = Math.max(maxSum, windowSum);
      }
      
      return maxSum;
   }
   
   /**
    * Test sliding window algorithm
    */
   public void testSlidingWindow() {
      // Test case 1: Basic case
      List<Integer> arr1 = Arrays.asList(1, 4, 2, 10, 2, 3, 
         1, 0, 20);
      int k1 = 4;
      System.out.println("Test 1: Window size " + k1);
      System.out.println("Array: " + arr1);
      System.out.println("Expected: 24 (sum of [2, 3, 1, 0])");
      System.out.println("Result: " + 
         maxSumSubarray(arr1, k1) + "\n");
      
      // Test case 2: Window equals array size
      List<Integer> arr2 = Arrays.asList(1, 4, 2, 10);
      int k2 = 4;
      System.out.println("Test 2: Window equals array size");
      System.out.println("Array: " + arr2);
      System.out.println("Expected: 17");
      System.out.println("Result: " + 
         maxSumSubarray(arr2, k2) + "\n");
      
      // Test case 3: Array smaller than window
      List<Integer> arr3 = Arrays.asList(1, 2);
      int k3 = 3;
      System.out.println("Test 3: Array smaller than window");
      System.out.println("Array: " + arr3);
      System.out.println("Expected: -1");
      System.out.println("Result: " + 
         maxSumSubarray(arr3, k3) + "\n");
   }
   
   /**
    * Main method to run tests
    */
   public static void main(String[] args) {
      SlidingWindow sw = new SlidingWindow();
      sw.testSlidingWindow();
   }
}