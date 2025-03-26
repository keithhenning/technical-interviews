using System;

public class PropertyProfitCalculator
{
   public static int MaxPropertyProfit(int[] prices)
   {
      if (prices == null || prices.Length < 2)
      {
         return 0;
      }

      int minPrice = int.MaxValue;
      int maxProfit = 0;

      foreach (int price in prices)
      {
         if (price < minPrice)
         {
            minPrice = price;
         }
         else
         {
            int currentProfit = price - minPrice;
            maxProfit = Math.Max(maxProfit, currentProfit);
         }
      }

      return maxProfit;
   }
}