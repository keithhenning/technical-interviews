public class OrangeGroveHarvest {
   public static double maxHarvest(int[][] grove, 
         double[] seasonalYield, int T) {
      int n = grove.length;
      int m = grove[0].length;
      
      // 3D DP array for harvest optimization
      double[][][] dp = new double[n][m][T+1];
      
      // Initialize with negative infinity
      for (int i = 0; i < n; i++) {
         for (int j = 0; j < m; j++) {
            for (int d = 0; d <= T; d++) {
               dp[i][j][d] = Double.NEGATIVE_INFINITY;
            }
         }
      }
      
      // Base case: start at first grove location
      dp[0][0][1] = grove[0][0] * seasonalYield[0];
      
      // Fill dynamic programming table
      for (int d = 1; d <= T; d++) {
         for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
               // Skip non-start locations on first day
               if (d == 1 && (i > 0 || j > 0)) {
                  continue;
               }
               
               // Move from top
               if (i > 0 && d > 1) {
                  dp[i][j][d] = Math.max(dp[i][j][d], 
                        dp[i-1][j][d-1] + grove[i][j] * 
                        seasonalYield[d-1]);
               }
               
               // Move from left
               if (j > 0 && d > 1) {
                  dp[i][j][d] = Math.max(dp[i][j][d], 
                        dp[i][j-1][d-1] + grove[i][j] * 
                        seasonalYield[d-1]);
               }
            }
         }
      }
      
      // Find maximum harvest at final location
      double maxHarvest = Double.NEGATIVE_INFINITY;
      for (int d = 1; d <= T; d++) {
         maxHarvest = Math.max(maxHarvest, dp[n-1][m-1][d]);
      }
      
      return maxHarvest;
   }
}