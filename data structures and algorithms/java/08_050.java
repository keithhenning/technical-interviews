class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    
    TreeNode(int x) {
        val = x;
    }
}

public class Solution {
    public TreeNode symmetrizeTree(TreeNode root) {
        if (root == null) {
            return null;
        }
        
        // Transform left and right subtrees first
        root.left = symmetrizeTree(root.left);
        root.right = symmetrizeTree(root.right);
        
        // Check if subtrees are symmetric
        if (!isSymmetric(root.left, root.right)) {
            // Not symmetric, make them symmetric
            if (root.left != null && root.right == null) {
                // Only left child exists, mirror it
                root.right = mirrorTree(root.left);
            } else if (root.right != null && root.left == null) {
                // Only right child exists, mirror it
                root.left = mirrorTree(root.right);
            } else {
                // Both children exist but not symmetric
                // Choose left subtree as reference and mirror it
                root.right = mirrorTree(root.left);
            }
        }
        
        return root;
    }
    
    private boolean isSymmetric(TreeNode left, TreeNode right) {
        if (left == null && right == null) {
            return true;
        }
        if (left == null || right == null) {
            return false;
        }
        if (left.val != right.val) {
            return false;
        }
        
        return isSymmetric(left.left, right.right) && 
               isSymmetric(left.right, right.left);
    }
    
    private TreeNode mirrorTree(TreeNode node) {
        if (node == null) {
            return null;
        }
        
        TreeNode mirrored = new TreeNode(node.val);
        mirrored.left = mirrorTree(node.right);
        mirrored.right = mirrorTree(node.left);
        
        return mirrored;
    }
}