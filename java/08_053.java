import java.util.ArrayList;
import java.util.List;

/**
 * Binary tree node
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
 * Solution for balancing binary search trees
 */
public class Solution {
   /**
    * Convert any BST to a balanced BST
    */
   public TreeNode balanceBST(TreeNode root) {
      // Collect nodes in sorted order
      List<Integer> nodes = new ArrayList<>();
      inOrderTraversal(root, nodes);
      
      // Rebuild as balanced BST
      return buildBalancedBST(nodes, 0, nodes.size() - 1);
   }
   
   /**
    * Perform in-order traversal to get sorted values
    */
   private void inOrderTraversal(TreeNode node, 
         List<Integer> nodes) {
      if (node == null) {
         return;
      }
      
      inOrderTraversal(node.left, nodes);
      nodes.add(node.val);
      inOrderTraversal(node.right, nodes);
   }
   
   /**
    * Build balanced BST from sorted values
    */
   private TreeNode buildBalancedBST(List<Integer> values, 
         int start, int end) {
      if (start > end) {
         return null;
      }
      
      // Use middle element as root for balance
      int mid = (start + end) / 2;
      TreeNode node = new TreeNode(values.get(mid));
      
      // Build left and right subtrees
      node.left = buildBalancedBST(values, start, mid - 1);
      node.right = buildBalancedBST(values, mid + 1, end);
      
      return node;
   }
}