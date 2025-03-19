using System.Collections.Generic;

/**
 * Tree node with value and left/right pointers
 */
class TreeNode {
   public int Value;
   public TreeNode Left;
   public TreeNode Right;
   
   public TreeNode(int value) {
      this.Value = value;
      this.Left = null;
      this.Right = null;
   }
}

public class BinaryTree {
   /**
    * Perform inorder traversal (Left-Root-Right)
    */
   public List<int> InorderTraversal(TreeNode root) {
      List<int> result = new List<int>();
      InorderHelper(root, result);
      return result;
   }
   
   /**
    * Helper for inorder traversal
    */
   private void InorderHelper(TreeNode node, List<int> result) {
      if (node != null) {
         InorderHelper(node.Left, result);
         result.Add(node.Value);
         InorderHelper(node.Right, result);
      }
   }
   
   /**
    * Perform preorder traversal (Root-Left-Right)
    */
   public List<int> PreorderTraversal(TreeNode root) {
      List<int> result = new List<int>();
      PreorderHelper(root, result);
      return result;
   }
   
   /**
    * Helper for preorder traversal
    */
   private void PreorderHelper(TreeNode node, List<int> result) {
      if (node != null) {
         result.Add(node.Value);
         PreorderHelper(node.Left, result);
         PreorderHelper(node.Right, result);
      }
   }
   
   /**
    * Perform postorder traversal (Left-Right-Root)
    */
   public List<int> PostorderTraversal(TreeNode root) {
      List<int> result = new List<int>();
      PostorderHelper(root, result);
      return result;
   }
   
   /**
    * Helper for postorder traversal
    */
   private void PostorderHelper(TreeNode node, List<int> result) {
      if (node != null) {
         PostorderHelper(node.Left, result);
         PostorderHelper(node.Right, result);
         result.Add(node.Value);
      }
   }
}
