#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
   // Find maximum joy from holiday cards
   int maxHolidayJoy(vector<int>& joyRatings, 
                    int minCards, int maxCards) {
      int n = joyRatings.size();
      // Check if we have enough cards
      if (n < minCards) {
         return 0;
      }
      
      // Calculate sum of initial minimum window
      int currentSum = 0;
      for (int i = 0; i < minCards; i++) {
         currentSum += joyRatings[i];
      }
      int maxJoy = currentSum;
      
      // Try each valid window size
      for (int windowSize = minCards; 
           windowSize <= min(maxCards, n); windowSize++) {
         // If increasing window size from previous iteration
         if (windowSize > minCards) {
            currentSum += joyRatings[windowSize - 1];
         }
         
         // Initial window of current size
         int tempMax = currentSum;
         
         // Slide the window across the array
         for (int i = windowSize; i < n; i++) {
            currentSum += joyRatings[i] - 
                         joyRatings[i - windowSize];
            tempMax = max(tempMax, currentSum);
         }
         
         maxJoy = max(maxJoy, tempMax);
         
         // Reset currentSum for next window size
         currentSum = 0;
         for (int i = 0; i < windowSize; i++) {
            currentSum += joyRatings[i];
         }
      }
      
      return maxJoy;
   }
};