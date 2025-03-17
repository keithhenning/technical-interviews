#include <vector>
#include <algorithm>
#include <limits>

// Calculate maximum orange harvest over T days
double maxOrangeHarvest(
      const std::vector<std::vector<int>>& grove, 
      const std::vector<double>& seasonalYield, int T) {
   int n = grove.size();
   int m = grove[0].size();
   
   // Create 3D DP array [position][position][day]
   std::vector<std::vector<std::vector<double>>> dp(
      n, std::vector<std::vector<double>>(
         m, std::vector<double>(
            T+1, -std::numeric_limits<double>::infinity())));
   
   // Base case: starting position on day 1
   dp[0][0][1] = grove[0][0] * seasonalYield[0];
   
   // Fill the DP table
   for (int d = 1; d <= T; d++) {
      for (int i = 0; i < n; i++) {
         for (int j = 0; j < m; j++) {
            // Skip if it's the first day and not at start
            if (d == 1 && (i > 0 || j > 0)) {
               continue;
            }
            
            // Consider moving from the top
            if (i > 0 && d > 1) {
               dp[i][j][d] = std::max(dp[i][j][d], 
                  dp[i-1][j][d-1] + 
                  grove[i][j] * seasonalYield[d-1]);
            }
            
            // Consider moving from the left
            if (j > 0 && d > 1) {
               dp[i][j][d] = std::max(dp[i][j][d], 
                  dp[i][j-1][d-1] + 
                  grove[i][j] * seasonalYield[d-1]);
            }
         }
      }
   }
   
   // Find max harvest among all possible ending days
   double maxHarvest = 
      -std::numeric_limits<double>::infinity();
   for (int d = 1; d <= T; d++) {
      maxHarvest = std::max(maxHarvest, dp[n-1][m-1][d]);
   }
   
   return maxHarvest;
}