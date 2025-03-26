using System;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   /**
    * A node in a linked list with data and next reference
    */
   public static class Node
   {
      // The value stored in the node
      public object Data;

      // Reference to the next node (null if none)
      public Node Next;

      /**
       * Initialize a new Node with data
       */
      public Node(object data)
      {
         this.Data = data;
         this.Next = null;
      }
   }

   /**
    * A singly linked list data structure
    */
   public static class LinkedList
   {
      // Reference to the first node
      private Node Head;

      // Reference to the last node
      private Node Tail;

      // Number of nodes in the list
      private int Length;

      /**
       * Initialize an empty linked list
       */
      public LinkedList()
      {
         this.Head = null;
         this.Tail = null;
         this.Length = 0;
      }

      /**
       * Add a new node to the end of the list
       */
      public LinkedList Push(object data)
      {
         // Create a new node
         Node newNode = new Node(data);

         // Case 1: Empty List
         if (this.Head == null)
         {
            this.Head = newNode;
            this.Tail = newNode;
         }
         // Case 2: List has nodes
         else
         {
            this.Tail.Next = newNode;
            this.Tail = newNode;
         }

         this.Length++;
         return this;
      }

      /**
       * Print the list elements from head to tail
       */
      public void Display()
      {
         // Start at the head node
         Node current = this.Head;
         while (current != null)
         {
            Console.Write(current.Data + " -> ");
            current = current.Next;
         }
         Console.WriteLine("null");
      }
   }

   // Example usage
   public void LinkedListExample()
   {
      LinkedList list = new LinkedList();
      list.Push(1);
      list.Push(2);
      list.Push(3);
      list.Display(); // 1 -> 2 -> 3 -> null
   }
}
