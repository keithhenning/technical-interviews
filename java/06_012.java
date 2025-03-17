import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Deque;
import java.util.List;

/**
 * A basic binary tree node implementation
 */
class TreeNode {
   int value;
   TreeNode left;
   TreeNode right;
   
   /**
    * Create new tree node with specified value
    */
   public TreeNode(int value) {
      this.value = value;
      this.left = null;
      this.right = null;
   }
}

public class BinaryTreeTraversal {
   /**
    * Perform level-order traversal using BFS
    */
   public static List<List<Integer>> breadthFirstSearch(
         TreeNode root) {
      // Handle empty tree case
      if (root == null) {
         return new ArrayList<>();
      }
      
      // Result list to store levels
      List<List<Integer>> result = new ArrayList<>();
      // Queue for BFS traversal
      Deque<TreeNode> queue = new ArrayDeque<>();
      // Start with root node
      queue.add(root);
      
      // Process nodes level by level
      while (!queue.isEmpty()) {
         // Get number of nodes at current level
         int levelSize = queue.size();
         // Store values at this level
         List<Integer> currentLevel = new ArrayList<>();
         
         // Process all nodes at current level
         for (int i = 0; i < levelSize; i++) {
            // Get next node from queue
            TreeNode node = queue.pollFirst();
            // Add value to current level
            currentLevel.add(node.value);
            
            // Add children to queue
            if (node.left != null) {
               queue.add(node.left);
            }
            if (node.right != null) {
               queue.add(node.right);
            }
         }
         
         // Add completed level to result
         result.add(currentLevel);
      }
      
      return result;
   }
}