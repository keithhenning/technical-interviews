import java.util.Arrays;

public class InsertionSort {
  /**
   * Sort array using insertion sort algorithm
   */
  public static void insertionSort(int[] arr) {
     int n = arr.length;
     
     for (int i = 1; i < n; i++) {
        // Store current element as key
        int key = arr[i];
        int j = i - 1;
        
        // Shift elements greater than key to right
        while (j >= 0 && arr[j] > key) {
           arr[j + 1] = arr[j];
           j--;
        }
        
        // Place key in correct position
        arr[j + 1] = key;
     }
  }
  
  public static void main(String[] args) {
     int[] numbers = {23, 16, 6, 59, 3, 11, 37};
     System.out.println("Original array: " + 
        Arrays.toString(numbers));
     insertionSort(numbers);
     System.out.println("Sorted array: " + 
        Arrays.toString(numbers));
  }
}