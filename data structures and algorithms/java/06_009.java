import java.util.ArrayList;
import java.util.List;

/**
 * Tree node with value and left/right pointers
 */
class TreeNode {
   int val;
   TreeNode left;
   TreeNode right;
   
   TreeNode(int val) {
      this.val = val;
      this.left = null;
      this.right = null;
   }
}

public class BinaryTree {
   /**
    * Perform inorder traversal (Left-Root-Right)
    */
   public List<Integer> inorderTraversal(TreeNode root) {
      List<Integer> result = new ArrayList<>();
      inorderHelper(root, result);
      return result;
   }
   
   /**
    * Helper for inorder traversal
    */
   private void inorderHelper(TreeNode node, 
         List<Integer> result) {
      if (node != null) {
         inorderHelper(node.left, result);
         result.add(node.val);
         inorderHelper(node.right, result);
      }
   }
   
   /**
    * Perform preorder traversal (Root-Left-Right)
    */
   public List<Integer> preorderTraversal(TreeNode root) {
      List<Integer> result = new ArrayList<>();
      preorderHelper(root, result);
      return result;
   }
   
   /**
    * Helper for preorder traversal
    */
   private void preorderHelper(TreeNode node, 
         List<Integer> result) {
      if (node != null) {
         result.add(node.val);
         preorderHelper(node.left, result);
         preorderHelper(node.right, result);
      }
   }
   
   /**
    * Perform postorder traversal (Left-Right-Root)
    */
   public List<Integer> postorderTraversal(TreeNode root) {
      List<Integer> result = new ArrayList<>();
      postorderHelper(root, result);
      return result;
   }
   
   /**
    * Helper for postorder traversal
    */
   private void postorderHelper(TreeNode node, 
         List<Integer> result) {
      if (node != null) {
         postorderHelper(node.left, result);
         postorderHelper(node.right, result);
         result.add(node.val);
      }
   }
}