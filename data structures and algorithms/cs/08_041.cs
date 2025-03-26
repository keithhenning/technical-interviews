using System;

public class ProcessingSpeedCalculator
{
   public static int MinProcessingSpeed(
      int[] batches, int h)
   {
      int left = 1;
      int right = 0;

      foreach (int batch in batches)
      {
         right = Math.Max(right, batch);
      }

      while (left < right)
      {
         int mid = left + (right - left) / 2;
         if (CanComplete(batches, mid, h))
         {
            right = mid;
         }
         else
         {
            left = mid + 1;
         }
      }

      return left;
   }

   private static bool CanComplete(
      int[] batches, int speed, int h)
   {
      int hours = 0;
      foreach (int batch in batches)
      {
         hours += (batch + speed - 1) / speed;
      }
      return hours <= h;
   }
}