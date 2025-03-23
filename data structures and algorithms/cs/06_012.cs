using System;
using System.Collections.Generic;

/**
 * A basic binary tree node implementation
 */
class TreeNode
{
   public int Value;
   public TreeNode Left;
   public TreeNode Right;

   /**
    * Create new tree node with specified value
    */
   public TreeNode(int value)
   {
      this.Value = value;
      this.Left = null;
      this.Right = null;
   }
}

public class BinaryTreeTraversal
{
   /**
    * Perform level-order traversal using BFS
    */
   public static List<List<int>> BreadthFirstSearch(TreeNode root)
   {
      // Handle empty tree case
      if (root == null)
      {
         return new List<List<int>>();
      }

      // Result list to store levels
      List<List<int>> result = new List<List<int>>();
      // Queue for BFS traversal
      Queue<TreeNode> queue = new Queue<TreeNode>();
      // Start with root node
      queue.Enqueue(root);

      // Process nodes level by level
      while (queue.Count > 0)
      {
         // Get number of nodes at current level
         int levelSize = queue.Count;
         // Store values at this level
         List<int> currentLevel = new List<int>();

         // Process all nodes at current level
         for (int i = 0; i < levelSize; i++)
         {
            // Get next node from queue
            TreeNode node = queue.Dequeue();
            // Add value to current level
            currentLevel.Add(node.Value);

            // Add children to queue
            if (node.Left != null)
            {
               queue.Enqueue(node.Left);
            }
            if (node.Right != null)
            {
               queue.Enqueue(node.Right);
            }
         }

         // Add completed level to result
         result.Add(currentLevel);
      }

      return result;
   }
}
