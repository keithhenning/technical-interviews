import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

/**
 * A basic binary tree node implementation
 */
class TreeNode {
   int value;
   TreeNode left;
   TreeNode right;
   
   /**
    * Create tree node with given value
    */
   public TreeNode(int value) {
      this.value = value;
      this.left = null;
      this.right = null;
   }
}

/**
 * Depth-First Search (DFS) tree traversal
 */
class DFSTree {
   /**
    * Recursive DFS traversal in pre-order
    */
   public List<Integer> dfsRecursive(TreeNode root) {
      List<Integer> result = new ArrayList<>();
      explore(root, result);
      return result;
   }
   
   /**
    * Helper method for recursive traversal
    */
   private void explore(TreeNode node, List<Integer> result) {
      if (node == null) {
         return;
      }
      
      // Pre-order: Process node first
      result.add(node.value);
      
      // Then go left and right
      explore(node.left, result);
      explore(node.right, result);
   }
   
   /**
    * Iterative DFS traversal using stack
    */
   public List<Integer> dfsIterative(TreeNode root) {
      if (root == null) {
         return new ArrayList<>();
      }
      
      List<Integer> result = new ArrayList<>();
      Stack<TreeNode> stack = new Stack<>();
      stack.push(root);
      
      while (!stack.isEmpty()) {
         // Get and process top node
         TreeNode node = stack.pop();
         result.add(node.value);
         
         // Push right first so left is processed first
         if (node.right != null) {
            stack.push(node.right);
         }
         if (node.left != null) {
            stack.push(node.left);
         }
      }
      
      return result;
   }
}