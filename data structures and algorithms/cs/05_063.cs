using System;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   // Optimized Valid Anagram
   public bool IsAnagramOptimized(string s, string t)
   {
      if (s.Length != t.Length)
      {
         return false;
      }

      int[] count = new int[26];

      for (int i = 0; i < s.Length; i++)
      {
         count[s[i] - 'a']++;
         count[t[i] - 'a']--;
      }

      for (int i = 0; i < 26; i++)
      {
         if (count[i] != 0)
         {
            return false;
         }
      }

      return true;  // Clean but mention the tradeoffs!
   }
}
