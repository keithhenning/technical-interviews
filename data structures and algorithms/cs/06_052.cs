using System;
using System.Collections.Generic;

public class Solution
{
   /**
    * Find length of longest substring without repeating chars
    */
   public int LengthOfLongestSubstring(string s)
   {
      // Track character positions
      Dictionary<char, int> charIndex =
         new Dictionary<char, int>();
      int maxLength = 0;
      int windowStart = 0;

      // Slide window through string
      for (int windowEnd = 0; windowEnd < s.Length; windowEnd++)
      {
         char currentChar = s[windowEnd];

         // If char already in current window, shrink window
         if (charIndex.ContainsKey(currentChar) &&
            charIndex[currentChar] >= windowStart)
         {
            // Move start to position after the duplicate
            windowStart = charIndex[currentChar] + 1;
         }
         else
         {
            // Update max length when no duplicate found
            maxLength = Math.Max(
               maxLength,
               windowEnd - windowStart + 1);
         }

         // Update character position
         charIndex[currentChar] = windowEnd;
      }

      return maxLength;
   }
}