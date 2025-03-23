using System;
using System.Collections.Generic;

public class DFSTree
{
   public List<int> DfsRecursive(TreeNode root)
   {
      var result = new List<int>();
      Explore(root, result);
      return result;
   }

   private void Explore(TreeNode node, List<int> result)
   {
      if (node == null)
      {
         return;
      }

      // Pre-order: Process node first
      result.Add(node.Value);

      // Then go left and right
      Explore(node.Left, result);
      Explore(node.Right, result);
   }

   public List<int> DfsIterative(TreeNode root)
   {
      if (root == null)
      {
         return new List<int>();
      }

      var result = new List<int>();
      var stack = new Stack<TreeNode>();
      stack.Push(root);

      while (stack.Count > 0)
      {
         var node = stack.Pop();
         result.Add(node.Value);

         if (node.Right != null)
         {
            stack.Push(node.Right);
         }
         if (node.Left != null)
         {
            stack.Push(node.Left);
         }
      }

      return result;
   }
}

public class TreeNode
{
   public int Value { get; set; }
   public TreeNode Left { get; set; }
   public TreeNode Right { get; set; }

   public TreeNode(int value)
   {
      Value = value;
      Left = null;
      Right = null;
   }
}
