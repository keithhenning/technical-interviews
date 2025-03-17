public int getTreeDepth(TreeNode root) {
   if (root == null) {
       return 0;
   }
   
   int depth = 0;
   Deque<TreeNode> queue = new ArrayDeque<>();
   queue.add(root);
   
   while (!queue.isEmpty()) {
       depth += 1;
       int levelSize = queue.size();
       
       for (int i = 0; i < levelSize; i++) {
           TreeNode node = queue.pollFirst();
           if (node.left != null) queue.add(node.left);
           if (node.right != null) queue.add(node.right);
       }
   }
   
   return depth;
}