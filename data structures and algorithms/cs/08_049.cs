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
   public bool MatchingPath(TreeNode root1, TreeNode root2)
   {
      var paths1 = new List<List<int>>();
      var paths2 = new List<List<int>>();

      CollectPaths(root1, new List<int>(), paths1);
      CollectPaths(root2, new List<int>(), paths2);

      foreach (var path1 in paths1)
      {
         if (paths2.Contains(path1))
         {
            return true;
         }
      }

      return false;
   }

   private void CollectPaths(TreeNode node,
                             List<int> currentPath,
                             List<List<int>> allPaths)
   {
      if (node == null)
      {
         return;
      }

      currentPath.Add(node.Val);

      if (node.Left == null && node.Right == null)
      {
         allPaths.Add(new List<int>(currentPath));
      }
      else
      {
         CollectPaths(node.Left, currentPath, allPaths);
         CollectPaths(node.Right, currentPath, allPaths);
      }

      currentPath.RemoveAt(currentPath.Count - 1);
   }
}