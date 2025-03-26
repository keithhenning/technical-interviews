using System;

public class Solution
{
   public int MaxHolidayJoy(
      int[] joyRatings,
      int minCards,
      int maxCards)
   {
      int n = joyRatings.Length;
      if (n < minCards)
      {
         return 0;
      }

      int currentSum = 0;
      for (int i = 0; i < minCards; i++)
      {
         currentSum += joyRatings[i];
      }
      int maxJoy = currentSum;

      for (int windowSize = minCards;
         windowSize <= Math.Min(maxCards, n);
         windowSize++)
      {
         if (windowSize > minCards)
         {
            currentSum += joyRatings[windowSize - 1];
         }

         int tempMax = currentSum;

         for (int i = windowSize; i < n; i++)
         {
            currentSum += joyRatings[i] -
               joyRatings[i - windowSize];
            tempMax = Math.Max(tempMax, currentSum);
         }

         maxJoy = Math.Max(maxJoy, tempMax);

         currentSum = 0;
         for (int i = 0; i < windowSize; i++)
         {
            currentSum += joyRatings[i];
         }
      }

      return maxJoy;
   }
}
