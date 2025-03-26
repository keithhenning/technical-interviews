using System;

public class QuickSelect
{
   /**
    * Finds the kth smallest element in an unordered array
    * @param arr Input array of integers
    * @param k The k-th smallest element to find (0-based)
    * @return The k-th smallest element in the array
    */
   public static int Quickselect(int[] arr, int k)
   {
      return Select(arr, 0, arr.Length - 1, k);
   }

   private static int Partition(
      int[] arr,
      int left,
      int right,
      int pivotIndex
   )
   {
      int pivotValue = arr[pivotIndex];
      Swap(arr, pivotIndex, right);

      int storeIndex = left;
      for (int i = left; i < right; i++)
      {
         if (arr[i] < pivotValue)
         {
            Swap(arr, storeIndex, i);
            storeIndex++;
         }
      }

      Swap(arr, right, storeIndex);
      return storeIndex;
   }

   private static int Select(
      int[] arr,
      int left,
      int right,
      int k
   )
   {
      if (left == right)
      {
         return arr[left];
      }

      int pivotIndex = (left + right) / 2;
      pivotIndex = Partition(arr, left, right, pivotIndex);

      if (k == pivotIndex)
      {
         return arr[k];
      }
      else if (k < pivotIndex)
      {
         return Select(arr, left, pivotIndex - 1, k);
      }
      else
      {
         return Select(arr, pivotIndex + 1, right, k);
      }
   }

   private static void Swap(int[] arr, int i, int j)
   {
      int temp = arr[i];
      arr[i] = arr[j];
      arr[j] = temp;
   }

   public static void Main(string[] args)
   {
      int[] arr = {
         3, 2, 1,
         5, 6, 4
      };
      int k = 2; // Find 3rd smallest element (0-based)

      Console.WriteLine(
         "Original array: " + ArrayToString(arr)
      );
      int result = Quickselect(arr, k);
      Console.WriteLine(
         $"The {k + 1}th smallest element is: {result}"
      );
      Console.WriteLine(
         "Note: Array may be partially sorted " +
         "after running quickselect: " +
         ArrayToString(arr)
      );
   }

   private static string ArrayToString(int[] arr)
   {
      return "[" + string.Join(", ", arr) + "]";
   }
}