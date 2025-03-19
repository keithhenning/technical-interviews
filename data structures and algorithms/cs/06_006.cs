using System;

public class InsertionSort {
  /**
   * Sort array using insertion sort algorithm
   */
  public static void InsertionSort(int[] arr) {
     int n = arr.Length;
     
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
  
  public static void Main(string[] args) {
     int[] numbers = {23, 16, 6, 59, 3, 11, 37};
     Console.WriteLine("Original array: " + 
        string.Join(", ", numbers));
     InsertionSort(numbers);
     Console.WriteLine("Sorted array: " + 
        string.Join(", ", numbers));
  }
}
