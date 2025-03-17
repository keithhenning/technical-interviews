import java.util.*;

/**
 * Binary tree node definition
 */
class TreeNode {
   int val;
   TreeNode left;
   TreeNode right;
   
   TreeNode(int x) {
      val = x;
   }
}

/**
 * Solution for finding matching paths between two trees
 */
public class Solution {
   /**
    * Check if there's at least one matching path
    */
   public boolean matchingPath(TreeNode root1, TreeNode root2) {
      List<List<Integer>> paths1 = new ArrayList<>();
      List<List<Integer>> paths2 = new ArrayList<>();
      
      // Collect all root-to-leaf paths from both trees
      collectPaths(root1, new ArrayList<>(), paths1);
      collectPaths(root2, new ArrayList<>(), paths2);
      
      // Check for any matching path
      for (List<Integer> path1 : paths1) {
         if (paths2.contains(path1)) {
            return true;
         }
      }
      
      return false;
   }
   
   /**
    * Recursively collect all root-to-leaf paths
    */
   private void collectPaths(TreeNode node, List<Integer> currentPath, 
         List<List<Integer>> allPaths) {
      if (node == null) {
         return;
      }
      
      // Add current node to path
      currentPath.add(node.val);
      
      // If leaf node, add path to results
      if (node.left == null && node.right == null) {
         allPaths.add(new ArrayList<>(currentPath));
      } else {
         // Continue traversal
         collectPaths(node.left, currentPath, allPaths);
         collectPaths(node.right, currentPath, allPaths);
      }
      
      // Backtrack
      currentPath.remove(currentPath.size() - 1);
   }
}