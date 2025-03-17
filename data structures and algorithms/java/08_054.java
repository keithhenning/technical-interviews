import java.util.*;

class TreeNode {
   int val;
   TreeNode left;
   TreeNode right;
   
   TreeNode(int x) {
      val = x;
   }
}

public class Solution {
   private Map<String, Integer> memo;
   
   /**
    * Find minimum possible height after removing k nodes
    */
   public int minHeightAfterRemoval(TreeNode root, int k) {
      memo = new HashMap<>();
      return dfs(root, k);
   }
   
   /**
    * DFS with memoization to explore removal options
    */
   private int dfs(TreeNode node, int remainingRemovals) {
      if (node == null) {
         return 0;
      }
      
      // Check if this state is already computed
      String key = node.toString() + ":" + remainingRemovals;
      if (memo.containsKey(key)) {
         return memo.get(key);
      }
      
      // Option 1: Remove this node (height becomes 0)
      int heightIfRemoved = 0;
      
      // Option 2: Keep this node
      int leftHeight = dfs(node.left, remainingRemovals);
      int rightHeight = dfs(node.right, remainingRemovals);
      int heightIfKept = 1 + Math.max(leftHeight, rightHeight);
      
      int minHeight = heightIfKept;
      
      // Try removing the node if possible
      if (remainingRemovals > 0) {
         minHeight = Math.min(minHeight, heightIfRemoved);
      }
      
      // Try removing subtrees in different combinations
      if (remainingRemovals > 0) {
         for (int removeLeft = 0; removeLeft <= remainingRemovals; 
               removeLeft++) {
            int removeRight = remainingRemovals - removeLeft;
            int heightRemoveSubtrees = 1 + Math.max(
               dfs(node.left, removeLeft),
               dfs(node.right, removeRight)
            );
            minHeight = Math.min(minHeight, heightRemoveSubtrees);
         }
      }
      
      // Cache result
      memo.put(key, minHeight);
      return minHeight;
   }
}