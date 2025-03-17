import java.util.Arrays;

public class QuickSort {
  /**
   * Sort array using quick sort algorithm
   */
  public static void quickSort(int[] arr, int low, int high) {
     if (low < high) {
        // Get partition index
        int pi = partition(arr, low, high);
        
        // Sort elements before and after partition
        quickSort(arr, low, pi - 1);
        quickSort(arr, pi + 1, high);
     }
  }
  
  /**
   * Partition array around pivot element
   */
  private static int partition(int[] arr, int low, 
        int high) {
     // Select rightmost element as pivot
     int pivot = arr[high];
     int i = (low - 1);
     
     // Move elements smaller than pivot to left
     for (int j = low; j < high; j++) {
        if (arr[j] <= pivot) {
           i++;
           
           // Swap elements
           int temp = arr[i];
           arr[i] = arr[j];
           arr[j] = temp;
        }
     }
     
     // Place pivot in correct position
     int temp = arr[i + 1];
     arr[i + 1] = arr[high];
     arr[high] = temp;
     
     return i + 1;
  }
  
  public static void main(String[] args) {
     int[] numbers = {23, 16, 6, 59, 3, 11, 37};
     System.out.println("Original array: " + 
        Arrays.toString(numbers));
     quickSort(numbers, 0, numbers.length - 1);
     System.out.println("Sorted array: " + 
        Arrays.toString(numbers));
  }
}