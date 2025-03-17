public class Solution {
   public boolean canCreateBlend(double[] acidity, 
         double targetAcidity) {
      int left = 0;
      int right = acidity.length - 1;
      
      while (left < right) {
         // Calculate blend acidity
         double blendAcidity = 
            (acidity[left] + acidity[right]) / 2;
         
         // Check if blend matches target
         if (Math.abs(blendAcidity - 
             targetAcidity) < 0.001) {
            return true;
         } else if (blendAcidity < targetAcidity) {
            left++;
         } else {
            right--;
         }
      }
      
      return false;
   }
}