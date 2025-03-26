using System;

public static class TestBoundaries
{
   /**
    * Test first window
    */
   public static int[] TestFirstWindow(int[] arr, int k)
   {
      /**
       * Test first window
       */
      int firstWindow = MaxSumSubarray(arr[0..k], k);
      /**
       * Test last window
       */
      int lastWindow = MaxSumSubarray(arr[^k..], k);
   }
}