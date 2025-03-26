k/**
 * Returns the top element without removing it
 */
public object Peek(Stack<object> stack)
{
   // Check for empty stack to prevent InvalidOperationException
   if (stack.Count == 0)
   {
      throw new InvalidOperationException("Stack is empty");
   }
   return stack.Peek();
}
