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
   public TreeNode BalanceBST(TreeNode root)
   {
      var nodes = new List<int>();
      InOrderTraversal(root, nodes);
      return BuildBalancedBST(nodes, 0,
                              nodes.Count - 1);
   }

   private void InOrderTraversal(TreeNode node,
                                 List<int> nodes)
   {
      if (node == null)
      {
         return;
      }

      InOrderTraversal(node.Left, nodes);
      nodes.Add(node.Val);
      InOrderTraversal(node.Right, nodes);
   }

   private TreeNode BuildBalancedBST(List<int> values,
                                     int start, int end)
   {
      if (start > end)
      {
         return null;
      }

      int mid = (start + end) / 2;
      TreeNode node = new TreeNode(values[mid]);
      node.Left = BuildBalancedBST(values, start,
                                   mid - 1);
      node.Right = BuildBalancedBST(values, mid + 1,
                                    end);
      return node;
   }
}