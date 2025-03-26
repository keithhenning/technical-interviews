using System;

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
   public TreeNode SymmetrizeTree(TreeNode root)
   {
      if (root == null)
      {
         return null;
      }

      root.Left = SymmetrizeTree(root.Left);
      root.Right = SymmetrizeTree(root.Right);

      if (!IsSymmetric(root.Left, root.Right))
      {
         if (root.Left != null && root.Right == null)
         {
            root.Right = MirrorTree(root.Left);
         }
         else if (root.Right != null && root.Left == null)
         {
            root.Left = MirrorTree(root.Right);
         }
         else
         {
            root.Right = MirrorTree(root.Left);
         }
      }

      return root;
   }

   private bool IsSymmetric(TreeNode left, TreeNode right)
   {
      if (left == null && right == null)
      {
         return true;
      }
      if (left == null || right == null)
      {
         return false;
      }
      if (left.Val != right.Val)
      {
         return false;
      }

      return IsSymmetric(left.Left, right.Right) &&
             IsSymmetric(left.Right, right.Left);
   }

   private TreeNode MirrorTree(TreeNode node)
   {
      if (node == null)
      {
         return null;
      }

      TreeNode mirrored = new TreeNode(node.Val);
      mirrored.Left = MirrorTree(node.Right);
      mirrored.Right = MirrorTree(node.Left);

      return mirrored;
   }
}