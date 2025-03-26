using System;
using System.Collections.Generic;

public class MedianOfMedians
{
   public static int Select(int[] arr, int k)
   {
      if (arr == null || arr.Length == 0 ||
         k < 0 || k >= arr.Length)
      {
         throw new ArgumentException("Invalid input");
      }

      return SelectHelper(arr, 0, arr.Length - 1, k);
   }

   private static int SelectHelper(int[] arr, int left,
      int right, int k)
   {
      if (left == right)
         return arr[left];

      int pivotIndex = GetPivotIndex(arr, left, right);
      pivotIndex = Partition(arr, left, right, pivotIndex);

      if (k == pivotIndex)
         return arr[k];
      else if (k < pivotIndex)
         return SelectHelper(arr, left, pivotIndex - 1, k);
      else
         return SelectHelper(arr, pivotIndex + 1, right, k);
   }

   private static int GetPivotIndex(int[] arr,
      int left, int right)
   {
      // If the array is small, return the middle element
      if (right - left < 5)
         return left + (right - left) / 2;

      // Divide the array into groups of 5 and find medians
      int numGroups = (right - left + 4) / 5;
      for (int i = 0; i < numGroups; i++)
      {
         int groupLeft = left + i * 5;
         int groupRight = Math.Min(groupLeft + 4, right);
         int medianIndex = groupLeft +
            (groupRight - groupLeft) / 2;
         Swap(arr, medianIndex, left + i);
      }

      return SelectHelper(arr, left, left + numGroups - 1,
         left + numGroups / 2);
   }

   private static void Swap(int[] arr, int i, int j)
   {
      int temp = arr[i];
      arr[i] = arr[j];
      arr[j] = temp;
   }

   private static int Partition(int[] arr,
      int left, int right, int pivotIndex)
   {
      int pivotValue = arr[pivotIndex];
      Swap(arr, pivotIndex, right);
      int storeIndex = left;

      for (int i = left; i < right; i++)
      {
         if (arr[i] < pivotValue)
         {
            Swap(arr, i, storeIndex);
            storeIndex++;
         }
      }

      Swap(arr, storeIndex, right);
      return storeIndex;
   }
}
