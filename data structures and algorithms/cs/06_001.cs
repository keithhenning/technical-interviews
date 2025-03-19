using System;

public class BubbleSort {
   /**
    * Sorts array using bubble sort algorithm
    */
   public static void BubbleSortArray(int[] arr) {
      int n = arr.Length;
      
      for (int i = 0; i < n; i++) {
         bool swapped = false;
         
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
   
   public static void Main(string[] args) {
      int[] numbers = {23, 16, 6, 59, 3, 11, 37};
      Console.WriteLine("Original array: " + string.Join(", ", numbers));
      BubbleSortArray(numbers);
      Console.WriteLine("Sorted array: " + string.Join(", ", numbers));
   }
}
