using System;
using System.Collections.Generic;

public class Solution 
{
   public List<List<string>> GroupAnagramsByFrequency(
      string[] strs) 
   {
      var groups = new Dictionary<string, List<string>>();
      var result = new List<List<string>>();

      foreach (var s in strs) 
      {
         var freq = new int[26];
         foreach (var c in s) 
         {
            freq[c - 'a']++;
         }

         var sb = new StringBuilder();
         for (int i = 0; i < 26; i++) 
         {
            sb.Append('#').Append(freq[i]);
         }
         var key = sb.ToString();

         if (!groups.ContainsKey(key)) 
         {
            groups[key] = new List<string>();
            result.Add(groups[key]);
         }
         groups[key].Add(s);
      }

      return result;
   }
}