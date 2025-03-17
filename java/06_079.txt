private static int medianOfThree(int[] arr, int low, int high) {
   int mid = (low + high) / 2;
   
   // Find median of first, middle, and last elements
   if (arr[low] > arr[mid]) {
       swap(arr, low, mid);
   }
   if (arr[mid] > arr[high]) {
       swap(arr, mid, high);
   }
   if (arr[low] > arr[mid]) {
       swap(arr, low, mid);
   }
   
   // Return the median as pivot (usually place it at position high-1)
   swap(arr, mid, high-1);
   return arr[high-1];
}