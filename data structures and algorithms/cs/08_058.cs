using System;

public class Solution
{
   public int KthAncestralElement(
      int[][] arrays,
      int k)
   {
      int left = int.MaxValue;
      int right = int.MinValue;

      foreach (var array in arrays)
      {
         if (array.Length > 0)
         {
            left = Math.Min(left, array[0]);
            right = Math.Max(
               right,
               array[array.Length - 1]
            );
         }
      }

      while (left < right)
      {
         int mid = left + (right - left) / 2;
         int count = 0;
         foreach (var array in arrays)
         {
            count += BinarySearch(array, mid);
         }

         if (count < k)
         {
            left = mid + 1;
         }
         else
         {
            right = mid;
         }
      }

      return left;
   }

   private int BinarySearch(int[] array, int target)
   {
      int left = 0, right = array.Length;

      while (left < right)
      {
         int mid = left + (right - left) / 2;
         if (array[mid] <= target)
         {
            left = mid + 1;
         }
         else
         {
            right = mid;
         }
      }

      return left;
   }
}