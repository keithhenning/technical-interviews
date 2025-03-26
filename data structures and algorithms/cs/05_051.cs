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

   public bool IsValidBST(Node root, long minVal, long maxVal)
   {
      if (root == null)
      {
         return true;
      }

      if (root.Key <= minVal || root.Key >= maxVal)
      {
         return false;
      }

      return (IsValidBST(root.Left, minVal, root.Key) &&
              IsValidBST(root.Right, root.Key, maxVal));
   }

   public bool IsValidBST(Node root)
   {
      return IsValidBST(root, long.MinValue, long.MaxValue);
   }
}
