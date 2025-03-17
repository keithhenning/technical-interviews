import java.util.HashMap;
import java.util.Map;

public class Solution {
   /**
    * Find length of longest substring without repeating chars
    */
   public int lengthOfLongestSubstring(String s) {
      // Track character positions
      Map<Character, Integer> charIndex = new HashMap<>();
      int maxLength = 0;
      int windowStart = 0;
      
      // Slide window through string
      for (int windowEnd = 0; windowEnd < s.length(); 
            windowEnd++) {
         char currentChar = s.charAt(windowEnd);
         
         // If char already in current window, shrink window
         if (charIndex.containsKey(currentChar) && 
             charIndex.get(currentChar) >= windowStart) {
            // Move start to position after the duplicate
            windowStart = charIndex.get(currentChar) + 1;
         } else {
            // Update max length when no duplicate found
            maxLength = Math.max(maxLength, 
               windowEnd - windowStart + 1);
         }
         
         // Update character position
         charIndex.put(currentChar, windowEnd);
      }
      
      return maxLength;
   }
}