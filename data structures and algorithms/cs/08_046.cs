using System.Collections.Generic;

public class TreeNode {
   public int Val { get; set; }
   public TreeNode Left { get; set; }
   public TreeNode Right { get; set; }
   public TreeNode Connection { get; set; }

   public TreeNode(int val) {
      Val = val;
   }
}

public class Solution {
   public TreeNode CloneTree(TreeNode root) {
      if (root == null) {
         return null;
      }

      var nodeMap = new Dictionary<TreeNode, TreeNode>();
      var newRoot = CloneStructure(root, nodeMap);
      SetConnections(root, nodeMap);
      return newRoot;
   }

   private TreeNode CloneStructure(
      TreeNode node, 
      Dictionary<TreeNode, TreeNode> nodeMap
   ) {
      if (node == null) {
         return null;
      }

      if (nodeMap.ContainsKey(node)) {
         return nodeMap[node];
      }

      var newNode = new TreeNode(node.Val);
      nodeMap[node] = newNode;
      newNode.Left = CloneStructure(node.Left, nodeMap);
      newNode.Right = CloneStructure(node.Right, nodeMap);
      return newNode;
   }

   private void SetConnections(
      TreeNode originalNode,
      Dictionary<TreeNode, TreeNode> nodeMap
   ) {
      if (originalNode == null) {
         return;
      }

      if (originalNode.Connection != null) {
         nodeMap[originalNode].Connection = 
            nodeMap[originalNode.Connection];
      }

      SetConnections(originalNode.Left, nodeMap);
      SetConnections(originalNode.Right, nodeMap);
   }
}