using System;
using System.Collections.Generic;

public class PatternMatcher
{
   public bool HasSamePattern(string str1, string str2)
   {
      if (str1.Length != str2.Length)
      {
         return false;
      }

      Dictionary<char, char> map1 = new Dictionary<char, char>();
      Dictionary<char, char> map2 = new Dictionary<char, char>();

      for (int i = 0; i < str1.Length; i++)
      {
         char c1 = str1[i];
         char c2 = str2[i];

         // Check mapping from str1 to str2
         if (map1.ContainsKey(c1))
         {
            if (map1[c1] != c2)
            {
               return false;
            }
         }
         else
         {
            map1[c1] = c2;
         }

         // Check mapping from str2 to str1
         if (map2.ContainsKey(c2))
         {
            if (map2[c2] != c1)
            {
               return false;
            }
         }
         else
         {
            map2[c2] = c1;
         }
      }

      return true;
   }
}