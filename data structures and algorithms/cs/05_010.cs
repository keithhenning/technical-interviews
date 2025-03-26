using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public void StackExample()
   {
      // Create an empty stack
      Stack<string> stack = new Stack<string>();
      // Push items onto stack
      stack.Push("first");
      stack.Push("second");
      // Pop - returns and removes "second"
      string lastItem = stack.Pop();
      // Peek at top item without removing
      string topItem = stack.Peek();
      // Check if empty
      bool isEmpty = stack.Count == 0;
   }

   public void ClearStack(Stack<string> stack)
   {
      stack.Clear();
   }
}
