using System;
using System.Collections.Generic;

public class TreeNode
{
   public int Value;
   public TreeNode Left;
   public TreeNode Right;

   public TreeNode(int value)
   {
      this.Value = value;
      this.Left = null;
      this.Right = null;
   }
}

public class TreeUtils
{
   public int GetTreeDepth(TreeNode root)
   {
      if (root == null)
      {
         return 0;
      }

      int depth = 0;
      Queue<TreeNode> queue = new Queue<TreeNode>();
      queue.Enqueue(root);

      while (queue.Count > 0)
      {
         depth += 1;
         int levelSize = queue.Count;

         for (int i = 0; i < levelSize; i++)
         {
            TreeNode node = queue.Dequeue();
            if (node.Left != null) queue.Enqueue(node.Left);
            if (node.Right != null) queue.Enqueue(node.Right);
         }
      }

      return depth;
   }
}
