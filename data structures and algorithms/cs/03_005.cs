using System;
using System.Globalization;

public class ComplexityDemo
{
   public static void DemonstrateComplexity()
   {
      DemonstrateComplexity(new int[] { 10, 100, 1000 });
   }

   public static void DemonstrateComplexity(int[] sizes)
   {
      // Create a number formatter
      NumberFormatInfo formatter = 
         CultureInfo.InvariantCulture.NumberFormat;

      foreach (int n in sizes)
      {
         // Calculate quadratic complexity operations
         long operations = (long)n * n;

         // Print the result
         Console.WriteLine("Size " + n + ": " + 
            operations.ToString("N0", formatter) + 
            " operations");
      }
   }

   public static void Main(string[] args)
   {
      DemonstrateComplexity();
   }
}