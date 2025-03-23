using System;
using System.Collections.Generic;

public class StringPermutations {
   public static List<string> GetPermutations(string str) {
      // Base case
      List<string> result = new List<string>();
      if (str.Length <= 1) {
         result.Add(str);
         return result;
      }
      
      // Recursive case
      for (int i = 0; i < str.Length; i++) {
         char currentChar = str[i];
         string remaining = str.Substring(0, i) + 
            str.Substring(i + 1);
         
         foreach (string perm in GetPermutations(remaining)) {
            result.Add(currentChar + perm);
         }
      }
      
      return result;
   }
   
   public static void Main(string[] args) {
      List<string> result = GetPermutations("abc");
      Console.WriteLine(string.Join(", ", result));
      // Output: abc, acb, bac, bca, cab, cba
   }
}