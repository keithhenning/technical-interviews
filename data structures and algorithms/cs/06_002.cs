using System;

public class MergeSort
{
   /**
    * Sort array using merge sort algorithm
    */
   public static void MergeSortArray(int[] arr)
   {
      if (arr.Length <= 1)
      {
         return;
      }

      int mid = arr.Length / 2;
      int[] left = new int[mid];
      int[] right = new int[arr.Length - mid];

      // Copy elements to left subarray
      Array.Copy(arr, 0, left, 0, mid);
      // Copy elements to right subarray
      Array.Copy(arr, mid, right, 0, arr.Length - mid);

      // Recursively sort both halves
      MergeSortArray(left);
      MergeSortArray(right);
      // Merge sorted halves
      Merge(arr, left, right);
   }

   /**
    * Merge two sorted arrays into a single sorted array
    */
   private static void Merge(int[] arr, int[] left, int[] right)
   {
      int i = 0, j = 0, k = 0;

      // Merge elements in sorted order
      while (i < left.Length && j < right.Length)
      {
         if (left[i] <= right[j])
         {
            arr[k++] = left[i++];
         }
         else
         {
            arr[k++] = right[j++];
         }
      }

      // Copy remaining left elements if any
      while (i < left.Length)
      {
         arr[k++] = left[i++];
      }

      // Copy remaining right elements if any
      while (j < right.Length)
      {
         arr[k++] = right[j++];
      }
   }

   public static void Main(string[] args)
   {
      int[] numbers = { 23, 16, 6, 59, 3, 11, 37 };
      Console.WriteLine("Original array: " +
         string.Join(", ", numbers));
      MergeSortArray(numbers);
      Console.WriteLine("Sorted array: " +
         string.Join(", ", numbers));
   }
}
