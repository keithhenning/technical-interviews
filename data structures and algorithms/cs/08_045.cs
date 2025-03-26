using System;

public class Solution
{
   public int MinProcessingPower(
      int[] tasks, int maxSeconds)
   {
      int maxTask = 0;
      foreach (int task in tasks)
      {
         maxTask = Math.Max(maxTask, task);
      }

      int left = 1;
      int right = maxTask;

      while (left < right)
      {
         int mid = left + (right - left) / 2;
         if (CanComplete(tasks, mid, maxSeconds))
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

   private bool CanComplete(
      int[] tasks, int power, int maxSeconds)
   {
      int totalTime = 0;
      foreach (int task in tasks)
      {
         totalTime += (task + power - 1) / power;
      }
      return totalTime <= maxSeconds;
   }
}