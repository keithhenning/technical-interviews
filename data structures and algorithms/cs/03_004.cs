using System;

public class MergeSort
{
   public static int[] MergeSortArray(int[] array)
   {
      if (array.Length <= 1)
         return array;

      int mid = array.Length / 2;
      int[] left = MergeSortArray(
         array[0..mid]);
      int[] right = MergeSortArray(
         array[mid..]);

      return Merge(left, right);
   }

   private static int[] Merge(int[] left, int[] right)
   {
      int[] result = new int[left.Length + right.Length];
      int i = 0, j = 0, k = 0;

      // Merge left and right arrays
      while (i < left.Length && j < right.Length)
         result[k++] = (left[i] <= right[j]) ?
            left[i++] : right[j++];

      // Copy remaining elements of left array
      while (i < left.Length)
         result[k++] = left[i++];

      // Copy remaining elements of right array
      while (j < right.Length)
         result[k++] = right[j++];

      return result;
   }

   public static void Main(string[] args)
   {
      int[] array = { 23, 16, 6, 59, 3, 11, 37 };
      Console.WriteLine(
         string.Join(", ", MergeSortArray(array)));
   }
}