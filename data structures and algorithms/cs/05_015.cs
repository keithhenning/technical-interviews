using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   /**
    * Returns the first element without removing it
    */
   public object Peek(Queue<object> queue)
   {
      // Returns null if queue is empty, no exception thrown
      return queue.Peek();
   }
}
