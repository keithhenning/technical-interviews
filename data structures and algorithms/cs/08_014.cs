using System;

public class ReverseLinkedList
{
   // Definition for singly-linked list
   public class ListNode
   {
      public int val;
      public ListNode next;

      public ListNode(int x)
      {
         val = x;
      }
   }

   public static ListNode ReverseList(ListNode head)
   {
      ListNode prev = null;
      ListNode current = head;

      while (current != null)
      {
         // Save the next node
         ListNode next = current.next;

         // Reverse the pointer
         current.next = prev;

         // Move pointers forward
         prev = current;
         current = next;
      }

      // prev is the new head
      return prev;
   }

   // Helper function to create a linked list from an array
   public static ListNode CreateLinkedList(int[] arr)
   {
      if (arr == null || arr.Length == 0)
      {
         return null;
      }

      ListNode head = new ListNode(arr[0]);
      ListNode current = head;

      for (int i = 1; i < arr.Length; i++)
      {
         current.next = new ListNode(arr[i]);
         current = current.next;
      }

      return head;
   }

   // Helper function to convert linked list 
   // to array for display
   public static int[] LinkedListToArray(ListNode head)
   {
      // First, count the number of nodes
      int count = 0;
      ListNode current = head;
      while (current != null)
      {
         count++;
         current = current.next;
      }

      int[] result = new int[count];
      current = head;
      int i = 0;

      while (current != null)
      {
         result[i++] = current.val;
         current = current.next;
      }

      return result;
   }

   // Helper to print array
   public static void PrintArray(int[] arr)
   {
      Console.Write("[");
      for (int i = 0; i < arr.Length; i++)
      {
         Console.Write(arr[i]);
         if (i < arr.Length - 1)
         {
            Console.Write(", ");
         }
      }
      Console.WriteLine("]");
   }

   public static void Main(string[] args)
   {
      ListNode list = CreateLinkedList(
                         new int[] { 1, 2, 3, 4, 5 }
                      );
      ListNode reversedList = ReverseList(list);
      PrintArray(LinkedListToArray(reversedList));
      // [5, 4, 3, 2, 1]
   }
}