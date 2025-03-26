using System;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class Node
   {
      public object Data;
      public Node Next;

      public Node(object data)
      {
         this.Data = data;
         this.Next = null;
      }
   }
}
