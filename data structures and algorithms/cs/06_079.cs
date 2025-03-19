private static int MedianOfThree(int[] arr, int low, int high) {
   int mid = (low + high) / 2;
   
   // Find median of first, middle, and last elements
   if (arr[low] > arr[mid]) {
       Swap(arr, low, mid);
   }
   if (arr[mid] > arr[high]) {
       Swap(arr, mid, high);
   }
   if (arr[low] > arr[mid]) {
       Swap(arr, low, mid);
   }
   
   // Return the median as pivot (usually place it at position high-1)
   Swap(arr, mid, high-1);
   return arr[high-1];
}

private static void Swap(int[] arr, int i, int j) {
   int temp = arr[i];
   arr[i] = arr[j];
   arr[j] = temp;
}