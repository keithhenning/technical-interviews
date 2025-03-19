public class OrangeGroveHarvest
{
   public static double MaxHarvest(
      int[][] grove,
      double[] seasonalYield, 
      int T)
   {
      int n = grove.Length;
      int m = grove[0].Length;

      double[,,] dp = new double[n, m, T + 1];

      for (int i = 0; i < n; i++)
      {
         for (int j = 0; j < m; j++)
         {
            for (int d = 0; d <= T; d++)
            {
               dp[i, j, d] = double.NegativeInfinity;
            }
         }
      }

      dp[0, 0, 1] = grove[0][0] * seasonalYield[0];

      for (int d = 1; d <= T; d++)
      {
         for (int i = 0; i < n; i++)
         {
            for (int j = 0; j < m; j++)
            {
               if (d == 1 && (i > 0 || j > 0))
               {
                  continue;
               }

               if (i > 0 && d > 1)
               {
                  dp[i, j, d] = Math.Max(
                     dp[i, j, d],
                     dp[i - 1, j, d - 1] + 
                        grove[i][j] * seasonalYield[d - 1]);
               }

               if (j > 0 && d > 1)
               {
                  dp[i, j, d] = Math.Max(
                     dp[i, j, d],
                     dp[i, j - 1, d - 1] + 
                        grove[i][j] * seasonalYield[d - 1]);
               }
            }
         }
      }

      double maxHarvest = double.NegativeInfinity;
      for (int d = 1; d <= T; d++)
      {
         maxHarvest = Math.Max(
            maxHarvest, 
            dp[n - 1, m - 1, d]);
      }

      return maxHarvest;
   }
}
