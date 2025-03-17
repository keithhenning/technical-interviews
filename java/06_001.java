import java.util.Arrays;

public class BubbleSort {
   /**
    * Sorts array using bubble sort algorithm
    */
   public static void bubbleSort(int[] arr) {
      int n = arr.length;
      
      for (int i = 0; i < n; i++) {
         boolean swapped = false;
         
         // Compare adjacent elements through array
         for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
               // Swap elements
               int temp = arr[j];
               arr[j] = arr[j + 1];
               arr[j + 1] = temp;
               swapped = true;
            }
         }
         
         // Early termination if no swaps occurred
         if (!swapped) {
            break;
         }
      }
   }
   
   public static void main(String[] args) {
      int[] numbers = {23, 16, 6, 59, 3, 11, 37};
      System.out.println("Original array: " + 
         Arrays.toString(numbers));
      bubbleSort(numbers);
      System.out.println("Sorted array: " + 
         Arrays.toString(numbers));
   }
}