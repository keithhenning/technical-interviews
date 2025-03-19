using System;
using System.Collections.Generic;

public class TrieNode 
{
   public Dictionary<char, TrieNode> Children { get; set; }
   public bool IsEndOfWord { get; set; }
   public int LastSearched { get; set; }

   public TrieNode() 
   {
      Children = new Dictionary<char, TrieNode>();
      IsEndOfWord = false;
      LastSearched = -1;
   }
}

public class SearchSuggestionSystem 
{
   private TrieNode dictionaryTrie;
   private TrieNode historyTrie;
   private int searchCount;

   public SearchSuggestionSystem(List<string> dictionary) 
   {
      dictionaryTrie = new TrieNode();
      historyTrie = new TrieNode();
      searchCount = 0;

      if (dictionary != null) 
      {
         foreach (var word in dictionary) 
         {
            AddToDictionary(word);
         }
      }
   }

   public void AddToDictionary(string word) 
   {
      var node = dictionaryTrie;
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

   public void AddToHistory(List<string> words) 
   {
      foreach (var word in words) 
      {
         searchCount++;
         var node = historyTrie;
         foreach (var c in word) 
         {
            if (!node.Children.ContainsKey(c)) 
            {
               node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
         }
         node.IsEndOfWord = true;
         node.LastSearched = searchCount;
         AddToDictionary(word);
      }
   }

   public List<string> Suggest(string prefix) 
   {
      var results = new List<string>();
      var historyMatches = new List<Pair<string, int>>();
      
      CollectSuggestions(
         historyTrie, 
         prefix, 
         new StringBuilder(), 
         historyMatches, 
         true);

      var dictMatches = new List<string>();
      CollectSuggestions(
         dictionaryTrie, 
         prefix, 
         new StringBuilder(), 
         dictMatches, 
         false);

      var seen = new HashSet<string>();

      historyMatches.Sort((a, b) => 
         b.Value.CompareTo(a.Value));
      foreach (var pair in historyMatches) 
      {
         var word = pair.Key;
         if (!seen.Contains(word)) 
         {
            results.Add(word);
            seen.Add(word);
         }
      }

      dictMatches.Sort();
      foreach (var word in dictMatches) 
      {
         if (!seen.Contains(word)) 
         {
            results.Add(word);
            seen.Add(word);
         }
      }

      return results;
   }

   private void CollectSuggestions(
      TrieNode root, 
      string prefix, 
      StringBuilder currentWord, 
      List<object> results, 
      bool isHistory) 
   {
      var node = root;

      foreach (var c in prefix) 
      {
         if (!node.Children.ContainsKey(c)) 
         {
            return;
         }
         node = node.Children[c];
         currentWord.Append(c);
      }

      DfsCollect(
         node, 
         new StringBuilder(currentWord.ToString()), 
         results, 
         isHistory);
   }

   private void DfsCollect(
      TrieNode node, 
      StringBuilder currentWord, 
      List<object> results, 
      bool isHistory) 
   {
      if (node.IsEndOfWord) 
      {
         if (isHistory) 
         {
            results.Add(new Pair<string, int>(
               currentWord.ToString(), 
               node.LastSearched));
         } 
         else 
         {
            results.Add(currentWord.ToString());
         }
      }

      var sortedChars = new List<char>(node.Children.Keys);
      sortedChars.Sort();

      foreach (var c in sortedChars) 
      {
         currentWord.Append(c);
         DfsCollect(
            node.Children[c], 
            currentWord, 
            results, 
            isHistory);
         currentWord.Length--;
      }
   }

   public class Pair<K, V> 
   {
      public K Key { get; set; }
      public V Value { get; set; }

      public Pair(K key, V value) 
      {
         Key = key;
         Value = value;
      }
   }
}