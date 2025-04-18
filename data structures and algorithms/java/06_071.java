public static int[] bucketSort(int[] arr, int k) {
   // Create k+1 buckets (for numbers 0 to k)
   int[] count = new int[k + 1];
   
   // Count occurrences of each element
   for (int num : arr) {
       count[num]++;
   }
   
   // Reconstruct the sorted array
   int[] sortedArr = new int[arr.length];
   int index = 0;
   for (int i = 0; i <= k; i++) {
       for (int j = 0; j < count[i]; j++) {
           sortedArr[index++] = i;
       }
   }
   
   return sortedArr;
}