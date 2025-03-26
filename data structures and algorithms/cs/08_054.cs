using System.Collections.Generic;

public class TreeNode
{
   public int Val { get; set; }
   public TreeNode Left { get; set; }
   public TreeNode Right { get; set; }

   public TreeNode(int x)
   {
      Val = x;
   }
}

public class Solution
{
   private Dictionary<string, int> memo;

   public int MinHeightAfterRemoval(
      TreeNode root, int k)
   {
      memo = new Dictionary<string, int>();
      return Dfs(root, k);
   }

   private int Dfs(TreeNode node,
      int remainingRemovals)
   {
      if (node == null)
      {
         return 0;
      }

      string key = node.ToString() +
         ":" + remainingRemovals;
      if (memo.ContainsKey(key))
      {
         return memo[key];
      }

      int heightIfRemoved = 0;
      int leftHeight = Dfs(node.Left,
         remainingRemovals);
      int rightHeight = Dfs(node.Right,
         remainingRemovals);
      int heightIfKept = 1 + Math.Max(
         leftHeight, rightHeight);

      int minHeight = heightIfKept;

      if (remainingRemovals > 0)
      {
         minHeight = Math.Min(minHeight,
            heightIfRemoved);
      }

      if (remainingRemovals > 0)
      {
         for (int removeLeft = 0;
            removeLeft <= remainingRemovals;
            removeLeft++)
         {
            int removeRight = remainingRemovals -
               removeLeft;
            int heightRemoveSubtrees = 1 + Math.Max(
               Dfs(node.Left, removeLeft),
               Dfs(node.Right, removeRight)
            );
            minHeight = Math.Min(
               minHeight,
               heightRemoveSubtrees);
         }
      }

      memo[key] = minHeight;
      return minHeight;
   }
}