/**
* Test first window
*/
public static int[] testBoundaries(int[] arr, int k) {
   /**
    * Test first window
    */
   int firstWindow = maxSumSubarray(
           Arrays.copyOfRange(arr, 0, k), k);
   /**
    * Test last window
    */
   int lastWindow = maxSumSubarray(
           Arrays.copyOfRange(arr, arr.length - k, arr.length), k);
}