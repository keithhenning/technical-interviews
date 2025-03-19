using System;
using System.Collections.Generic;
using System.Linq;

public class FuzzyWordFinder 
{
   private readonly TrieNode root;

   private class TrieNode 
   {
      public Dictionary<char, TrieNode> Children { get; set; }
      public bool IsEndOfWord { get; set; }

      public TrieNode() 
      {
         Children = new Dictionary<char, TrieNode>();
         IsEndOfWord = false;
      }
   }

   public FuzzyWordFinder(List<string> dictionary) 
   {
      root = new TrieNode();
      dictionary.ForEach(Insert);
   }

   private void Insert(string word) 
   {
      var node = root;
      foreach (var c in word) 
      {
         if (!node.Children.ContainsKey(c)) 
         {
            node.Children[c] = new TrieNode();
         }
         node = node.Children[c];
      }
      node.IsEndOfWord = true;
   }

   public List<string> Search(string query, int k) 
   {
      var matches = new List<Result>();
      Dfs(root, query, 0, new StringBuilder(), 
         0, matches, k);

      matches.Sort((a, b) => 
         a.Substitutions != b.Substitutions ? 
         a.Substitutions.CompareTo(b.Substitutions) : 
         a.Word.CompareTo(b.Word));

      return matches.Select(r => r.Word).ToList();
   }

   private void Dfs(
      TrieNode node, 
      string query, 
      int index,
      StringBuilder currentWord, 
      int substitutions,
      List<Result> results, 
      int k) 
   {
      if (index == query.Length) 
      {
         if (node.IsEndOfWord) 
         {
            results.Add(
               new Result(currentWord.ToString(), 
               substitutions));
         }
         return;
      }

      var currentChar = query[index];

      foreach (var entry in node.Children) 
      {
         var nextChar = entry.Key;
         var nextNode = entry.Value;

         if (nextChar == currentChar) 
         {
            currentWord.Append(nextChar);
            Dfs(nextNode, query, index + 1,
               currentWord, substitutions, results, k);
            currentWord.Length--;
         } 
         else if (substitutions < k) 
         {
            currentWord.Append(nextChar);
            Dfs(nextNode, query, index + 1,
               currentWord, substitutions + 1, results, k);
            currentWord.Length--;
         }
      }
   }

   private class Result 
   {
      public string Word { get; set; }
      public int Substitutions { get; set; }

      public Result(string word, int substitutions) 
      {
         Word = word;
         Substitutions = substitutions;
      }
   }
}