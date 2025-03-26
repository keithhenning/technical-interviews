public class TrieNode
{
   public TrieNode[] children;
   public bool isEnd;

   public TrieNode()
   {
      children = new TrieNode[26];
      isEnd = false;
   }
}

public class Trie
{
   private TrieNode root;

   public Trie()
   {
      root = new TrieNode();
   }

   public void Insert(string word)
   {
      TrieNode node = root;
      foreach (char c in word.ToCharArray())
      {
         int index = c - 'a';
         if (node.children[index] == null)
         {
            node.children[index] = new TrieNode();
         }
         node = node.children[index];
      }
      node.isEnd = true;
   }

   public bool Search(string word)
   {
      TrieNode node = root;
      foreach (char c in word.ToCharArray())
      {
         int index = c - 'a';
         if (node.children[index] == null)
         {
            return false;
         }
         node = node.children[index];
      }
      return node.isEnd;
   }

   public bool StartsWith(string prefix)
   {
      TrieNode node = root;
      foreach (char c in prefix.ToCharArray())
      {
         int index = c - 'a';
         if (node.children[index] == null)
         {
            return false;
         }
         node = node.children[index];
      }
      return true;
   }
}