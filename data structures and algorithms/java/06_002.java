import java.util.Arrays;

public class MergeSort {
   /**
    * Sort array using merge sort algorithm
    */
   public static void mergeSort(int[] arr) {
      if (arr.length <= 1) {
         return;
      }
      
      int mid = arr.length / 2;
      int[] left = new int[mid];
      int[] right = new int[arr.length - mid];
      
      // Copy elements to left subarray
      for (int i = 0; i < mid; i++) {
         left[i] = arr[i];
      }
      // Copy elements to right subarray
      for (int i = mid; i < arr.length; i++) {
         right[i - mid] = arr[i];
      }
      
      // Recursively sort both halves
      mergeSort(left);
      mergeSort(right);
      // Merge sorted halves
      merge(arr, left, right);
   }
   
   /**
    * Merge two sorted arrays into a single sorted array
    */
   private static void merge(int[] arr, int[] left, 
         int[] right) {
      int i = 0, j = 0, k = 0;
      
      // Merge elements in sorted order
      while (i < left.length && j < right.length) {
         if (left[i] <= right[j]) {
            arr[k++] = left[i++];
         } else {
            arr[k++] = right[j++];
         }
      }
      
      // Copy remaining left elements if any
      while (i < left.length) {
         arr[k++] = left[i++];
      }
      
      // Copy remaining right elements if any
      while (j < right.length) {
         arr[k++] = right[j++];
      }
   }
   
   public static void main(String[] args) {
      int[] numbers = {23, 16, 6, 59, 3, 11, 37};
      System.out.println("Original array: " + 
         Arrays.toString(numbers));
      mergeSort(numbers);
      System.out.println("Sorted array: " + 
         Arrays.toString(numbers));
   }
}