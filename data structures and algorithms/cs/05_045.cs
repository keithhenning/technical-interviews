using System;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class BinaryTree
   {
      public int GetHeight(Node node)
      {
         if (node == null)
         {
            return 0;
         }
         return 1 + Math.Max(this.GetHeight(node.Left),
                           this.GetHeight(node.Right));
      }
   }
}
