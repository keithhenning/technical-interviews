import java.util.HashMap;
import java.util.Map;

/**
 * Tree node with additional connection pointer
 */
class TreeNode {
   int val;
   TreeNode left;
   TreeNode right;
   TreeNode connection;
   
   TreeNode(int val) {
      this.val = val;
   }
}

public class Solution {
   /**
    * Clone tree with all connections preserved
    */
   public TreeNode cloneTree(TreeNode root) {
      if (root == null) {
         return null;
      }
      
      // Map original nodes to their clones
      Map<TreeNode, TreeNode> nodeMap = new HashMap<>();
      
      // Phase 1: Clone basic tree structure
      TreeNode newRoot = cloneStructure(root, nodeMap);
      
      // Phase 2: Set up connections between cloned nodes
      setConnections(root, nodeMap);
      
      return newRoot;
   }
   
   /**
    * Clone basic tree structure (values, left/right pointers)
    */
   private TreeNode cloneStructure(TreeNode node, 
         Map<TreeNode, TreeNode> nodeMap) {
      if (node == null) {
         return null;
      }
      
      // Return existing clone if already created
      if (nodeMap.containsKey(node)) {
         return nodeMap.get(node);
      }
      
      // Create new node with same value
      TreeNode newNode = new TreeNode(node.val);
      nodeMap.put(node, newNode);
      
      // Recursively clone left and right subtrees
      newNode.left = cloneStructure(node.left, nodeMap);
      newNode.right = cloneStructure(node.right, nodeMap);
      
      return newNode;
   }
   
   /**
    * Set up connection pointers between cloned nodes
    */
   private void setConnections(TreeNode originalNode, 
         Map<TreeNode, TreeNode> nodeMap) {
      if (originalNode == null) {
         return;
      }
      
      // Map connection from original to its clone
      if (originalNode.connection != null) {
         nodeMap.get(originalNode).connection = 
            nodeMap.get(originalNode.connection);
      }
      
      // Process all nodes in the tree
      setConnections(originalNode.left, nodeMap);
      setConnections(originalNode.right, nodeMap);
   }
}