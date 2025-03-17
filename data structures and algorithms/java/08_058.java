class Solution {
   public int kthAncestralElement(int[][] arrays, 
         int k) {
      // Define search boundaries
      int left = Integer.MAX_VALUE;
      int right = Integer.MIN_VALUE;
      
      // Find min and max across arrays
      for (int[] array : arrays) {
         if (array.length > 0) {
            // Update left with min first element
            left = Math.min(left, array[0]);
            // Update right with max last element
            right = Math.max(right, 
               array[array.length - 1]);
         }
      }
      
      // Binary search for kth element
      while (left < right) {
         // Calculate midpoint safely
         int mid = left + (right - left) / 2;
         
         // Count elements <= mid
         int count = 0;
         for (int[] array : arrays) {
            // Binary search in each array
            count += binarySearch(array, mid);
         }
         
         // Adjust search boundaries
         if (count < k) {
            left = mid + 1;
         } else {
            right = mid;
         }
      }
      
      return left;
   }
   
   // Binary search to count elements
   private int binarySearch(int[] array, 
         int target) {
      int left = 0, right = array.length;
      
      while (left < right) {
         int mid = left + (right - left) / 2;
         if (array[mid] <= target) {
            left = mid + 1;
         } else {
            right = mid;
         }
      }
      
      // Return count of elements <= target
      return left;
   }
}