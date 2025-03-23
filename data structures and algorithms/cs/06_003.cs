using System;

public class QuickSort
{
   /**
    * Sort array using quick sort algorithm
    */
   public static void QuickSortArray(int[] arr, int low, int high)
   {
      if (low < high)
      {
         // Get partition index
         int pi = Partition(arr, low, high);

         // Sort elements before and after partition
         QuickSortArray(arr, low, pi - 1);
         QuickSortArray(arr, pi + 1, high);
      }
   }

   /**
    * Partition array around pivot element
    */
   private static int Partition(int[] arr, int low, int high)
   {
      // Select rightmost element as pivot
      int pivot = arr[high];
      int i = (low - 1);

      // Move elements smaller than pivot to left
      for (int j = low; j < high; j++)
      {
         if (arr[j] <= pivot)
         {
            i++;

            // Swap elements
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
         }
      }

      // Place pivot in correct position
      int temp1 = arr[i + 1];
      arr[i + 1] = arr[high];
      arr[high] = temp1;

      return i + 1;
   }

   public static void Main(string[] args)
   {
      int[] numbers = { 23, 16, 6, 59, 3, 11, 37 };
      Console.WriteLine("Original array: " +
          string.Join(", ", numbers));
      QuickSortArray(numbers, 0, numbers.Length - 1);
      Console.WriteLine("Sorted array: " +
          string.Join(", ", numbers));
   }
}
