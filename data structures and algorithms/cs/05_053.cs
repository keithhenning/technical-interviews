using System;

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

   public Node LowestCommonAncestor(Node root, Node p, Node q)
   {
      if (p.Key < root.Key && q.Key < root.Key)
      {
         return LowestCommonAncestor(root.Left, p, q);
      }
      else if (p.Key > root.Key && q.Key > root.Key)
      {
         return LowestCommonAncestor(root.Right, p, q);
      }
      else
      {
         return root;
      }
   }
}
