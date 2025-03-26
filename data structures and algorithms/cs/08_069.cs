using System;

public class Solution
{
   public bool CanCreateBlend(
      double[] acidity,
      double targetAcidity)
   {
      int left = 0;
      int right = acidity.Length - 1;

      while (left < right)
      {
         double blendAcidity =
            (acidity[left] + acidity[right]) / 2;

         if (Math.Abs(blendAcidity - targetAcidity) < 0.001)
         {
            return true;
         }
         else if (blendAcidity < targetAcidity)
         {
            left++;
         }
         else
         {
            right--;
         }
      }

      return false;
   }
}
