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
      public int Val { get; set; }
      public Node Left { get; set; }
      public Node Right { get; set; }

      public Node(int val)
      {
         Val = val;
      }
   }

   public int MaxDepth(Node root)
   {
      if (root == null)
      {
         return 0;
      }
      return 1 + Math.Max(MaxDepth(root.Left), MaxDepth(root.Right));
   }
}
