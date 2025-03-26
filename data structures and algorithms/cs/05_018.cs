using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   // Static inner class for better access
   public static class Stack<T>
   {
      // Initialize stack with an empty list
      private List<T> stack;

      public Stack()
      {
         this.stack = new List<T>();
      }

      // C# uses methods not properties
      public int GetLength()
      {
         return stack.Count;
      }

      public T Push(T item)
      {
         // Add item to the top of stack
         this.stack.Add(item);
         return item;
      }

      public T Pop()
      {
         // Remove and return the top item
         if (!this.IsEmpty())
         {
            T item = this.stack[this.stack.Count - 1];
            this.stack.RemoveAt(this.stack.Count - 1);
            return item;
         }
         // Better to throw exception than return null
         throw new InvalidOperationException("Stack is empty");
      }

      public T Peek()
      {
         // Look at the top item without removing
         if (!this.IsEmpty())
         {
            return this.stack[this.stack.Count - 1];
         }
         // Better to throw exception than return null
         throw new InvalidOperationException("Stack is empty");
      }

      public bool IsEmpty()
      {
         // Check if stack is empty
         return this.GetLength() == 0;
      }
   }

   // Test method
   public void TestStack()
   {
      Stack<string> album = new Stack<string>();
      album.Push("album 1");
      album.Push("album 2");
      album.Push("album 3");

      Console.WriteLine("Top album is: " + album.Peek());
      album.Pop();
      Console.WriteLine("Now the top album is: " + album.Peek());
      Console.WriteLine("Total albums in stack: " + album.GetLength());
   }
}
