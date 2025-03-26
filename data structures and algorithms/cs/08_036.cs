using System.Collections.Generic;

public class FrequencyThresholdChecker
{
   public static bool HasFrequencyThreshold(
      int[] nums, int k
   )
   {
      var counter = new Dictionary<int, int>();

      foreach (int num in nums)
      {
         if (!counter.ContainsKey(num))
         {
            counter[num] = 0;
         }
         counter[num]++;
         if (counter[num] >= k)
         {
            return true;
         }
      }

      return false;
   }
}