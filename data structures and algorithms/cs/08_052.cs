using System;
using System.Collections.Generic;

public class Solution
{
   public List<string> GenerateBracketExpressions(
      string expr)
   {
      var result = new HashSet<string>();
      string[] brackets = { "()", "[]", "{}" };

      for (int i = 0; i <= expr.Length; i++)
      {
         foreach (var bracket in brackets)
         {
            string newExpr = expr.Substring(0, i)
               + bracket[0] + expr.Substring(i);

            for (int j = i + 1; j <= newExpr.Length; j++)
            {
               string candidate = newExpr.Substring(0, j)
                  + bracket[1] + newExpr.Substring(j);
               if (IsValid(candidate))
               {
                  result.Add(candidate);
               }
            }
         }
      }

      foreach (var bracket in brackets)
      {
         string wrapped = bracket[0] + expr + bracket[1];
         if (IsValid(wrapped))
         {
            result.Add(wrapped);
         }
      }

      return new List<string>(result);
   }

   private bool IsValid(string expr)
   {
      var stack = new Stack<char>();
      var bracketMap = new Dictionary<char, char> {
         { ')', '(' },
         { ']', '[' },
         { '}', '{' }
      };

      foreach (var c in expr)
      {
         if (c == '(' || c == '[' || c == '{')
         {
            stack.Push(c);
         }
         else if (c == ')' || c == ']' || c == '}')
         {
            if (stack.Count == 0 || stack.Pop()
               != bracketMap[c])
            {
               return false;
            }
         }
      }

      return stack.Count == 0;
   }
}