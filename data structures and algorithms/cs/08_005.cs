using System;

public class ProductionResilience
{
   public int[] CalculateResilience(int[] production)
   {
      int n = production.Length;
      int[] resilience = new int[n];

      // Calculate products of all elements to the left
      int leftProduct = 1;
      for (int i = 0; i < n; i++)
      {
         resilience[i] = leftProduct;
         leftProduct *= production[i];
      }

      // Calculate products of all elements to the right 
      // and multiply with existing values
      int rightProduct = 1;
      for (int i = n - 1; i >= 0; i--)
      {
         resilience[i] *= rightProduct;
         rightProduct *= production[i];
      }

      return resilience;
   }
}