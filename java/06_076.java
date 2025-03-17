public class QuickSelect {
   /**
    * Finds the kth smallest element in an unordered array
    * @param arr Input array of integers
    * @param k The k-th smallest element to find (0-based)
    * @return The k-th smallest element in the array
    */
   public static int quickselect(int[] arr, int k) {
       return select(arr, 0, arr.length - 1, k);
   }
   
   private static int partition(int[] arr, int left, int right, 
           int pivotIndex) {
       int pivotValue = arr[pivotIndex];
       // Move pivot to end
       swap(arr, pivotIndex, right);
       
       int storeIndex = left;
       for (int i = left; i < right; i++) {
           if (arr[i] < pivotValue) {
               swap(arr, storeIndex, i);
               storeIndex++;
           }
       }
       
       // Move pivot to its final place
       swap(arr, right, storeIndex);
       return storeIndex;
   }
   
   private static int select(int[] arr, int left, int right, 
           int k) {
       if (left == right) {
           return arr[left];
       }
       
       // Choose pivot (using middle element for simplicity)
       int pivotIndex = (left + right) / 2;
       pivotIndex = partition(arr, left, right, pivotIndex);
       
       if (k == pivotIndex) {
           return arr[k];
       } else if (k < pivotIndex) {
           return select(arr, left, pivotIndex - 1, k);
       } else {
           return select(arr, pivotIndex + 1, right, k);
       }
   }
   
   private static void swap(int[] arr, int i, int j) {
       int temp = arr[i];
       arr[i] = arr[j];
       arr[j] = temp;
   }
   
   // Example usage with detailed output
   public static void main(String[] args) {
       int[] arr = {3, 2, 1, 5, 6, 4};
       int k = 2;  // Find 3rd smallest element (0-based index)
       
       System.out.println("Original array: " + 
               arrayToString(arr));
       int result = quickselect(arr, k);
       System.out.printf("The %dth smallest element is: %d%n", 
               k+1, result);
       System.out.println("Note: Array may be partially sorted" +
               " after running quickselect: " + 
               arrayToString(arr));
   }
   
   private static String arrayToString(int[] arr) {
       StringBuilder sb = new StringBuilder("[");
       for (int i = 0; i < arr.length; i++) {
           sb.append(arr[i]);
           if (i < arr.length - 1) {
               sb.append(", ");
           }
       }
       sb.append("]");
       return sb.toString();
   }
}