using System;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public void Remove(object target, Node head)
   {
      Node current = head;
      Node prev = null;
      while (current != null)
      {
         if (current.data.Equals(target))
         {
            prev.next = current.next;
            break;
         }
         prev = current;
         current = current.next;
      }
   }
}
