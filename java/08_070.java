public class Solution {
   public int maxHolidayJoy(int[] joyRatings, 
         int minCards, int maxCards) {
      // Return 0 if ratings array is too small
      int n = joyRatings.length;
      if (n < minCards) {
         return 0;
      }
      
      // Calculate initial minimum window sum
      int currentSum = 0;
      for (int i = 0; i < minCards; i++) {
         currentSum += joyRatings[i];
      }
      int maxJoy = currentSum;
      
      // Try each valid window size
      for (int windowSize = minCards; 
           windowSize <= Math.min(maxCards, n); 
           windowSize++) {
         // Expand window if larger than minimum
         if (windowSize > minCards) {
            currentSum += joyRatings[windowSize - 1];
         }
         
         // Initial window of current size
         int tempMax = currentSum;
         
         // Slide window across array
         for (int i = windowSize; i < n; i++) {
            currentSum += joyRatings[i] - 
                  joyRatings[i - windowSize];
            tempMax = Math.max(tempMax, currentSum);
         }
         
         maxJoy = Math.max(maxJoy, tempMax);
         
         // Reset current sum for next window
         currentSum = 0;
         for (int i = 0; i < windowSize; i++) {
            currentSum += joyRatings[i];
         }
      }
      
      return maxJoy;
   }
}