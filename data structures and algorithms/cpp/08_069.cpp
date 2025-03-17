#include <vector>
#include <cmath>
using namespace std;

class Solution {
public:
   // Check if a coffee blend with target acidity is possible
   bool canCreateBlend(vector<double>& acidity, 
                     double targetAcidity) {
      int left = 0;
      int right = acidity.size() - 1;
      
      // Use two pointers to find a viable blend
      while (left < right) {
         // Calculate the acidity of a potential blend
         double blendAcidity = (acidity[left] + acidity[right]) 
                             / 2.0;
         
         // Check if blend matches target (with small tolerance)
         if (abs(blendAcidity - targetAcidity) < 0.001) {
            return true;
         } 
         // Adjust pointers based on acidity comparison
         else if (blendAcidity < targetAcidity) {
            left++;
         } 
         else {
            right--;
         }
      }
      
      // No valid blend found
      return false;
   }
};