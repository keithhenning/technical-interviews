using System;
using System.Collections.Generic;

class TrieNode
{
   public Dictionary<char, TrieNode> Children { get; set; }
   public bool IsEnd { get; set; }

   public TrieNode()
   {
      this.Children = new Dictionary<char, TrieNode>();
      this.IsEnd = false;
   }
}

class Trie
{
   private TrieNode root;

   public Trie()
   {
      this.root = new TrieNode();
   }

   // Your implementation
   public void Insert(string word)
   {

   }

   // Your implementation  
   public bool Search(string word)
   {

   }

   // Your implementation
   public bool StartsWith(string prefix)
   {

   }
}