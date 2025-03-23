public IEnumerator<int> DfsWithYield(TreeNode node)
{
   // Create and return an IEnumerator implementation
   return new Enumerator(node);
}

private class Enumerator : IEnumerator<int>
{
   private Stack<object> stack = new Stack<object>();
   private int current;

   public Enumerator(TreeNode node)
   {
      // Initialize with the root node
      if (node != null)
      {
         stack.Push(node);
      }
   }

   public bool MoveNext()
   {
      while (stack.Count > 0)
      {
         object current = stack.Pop();

         // If current is a node, push its value and children
         if (current is TreeNode currentNode)
         {
            // Push right child first (LIFO)
            if (currentNode.Right != null)
            {
               stack.Push(currentNode.Right);
            }

            // Push left child
            if (currentNode.Left != null)
            {
               stack.Push(currentNode.Left);
            }

            // Push the value to return
            stack.Push(currentNode.Value);
         }
         else
         {
            // Return the value
            this.current = (int)current;
            return true;
         }
      }
      return false;
   }

   public int Current => current;

   object IEnumerator.Current => Current;

   public void Dispose() { }

   public void Reset()
   {
      throw new NotSupportedException();
   }
}
