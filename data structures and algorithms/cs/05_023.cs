using System;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class Node
   {
      public object data;
      public Node next;
      public Node prev;

      public Node(object data)
      {
         this.data = data;
         this.next = null;
         this.prev = null;
      }
   }

   public void PrintDoublyLinkedList(Node head)
   {
      Node current = head;
      while (current != null)
      {
         Console.Write(current.data + " ");
         current = current.next;
      }
      Console.WriteLine();
   }
}
