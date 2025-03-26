using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class Node
   {
      public int Key;
      public Node Left;
      public Node Right;

      public Node(int key)
      {
         this.Key = key;
      }
   }

   public int KthSmallest(Node root, int k)
   {
      // Perform inorder traversal and return the kth element
      List<int> result = new List<int>();

      Inorder(root, result, k);

      return k <= result.Count ? result[k - 1] : -1;
   }

   private void Inorder(Node node, List<int> result, int k)
   {
      if (node == null || result.Count >= k)
      {
         return;
      }
      Inorder(node.Left, result, k);
      result.Add(node.Key);
      Inorder(node.Right, result, k);
   }
}
