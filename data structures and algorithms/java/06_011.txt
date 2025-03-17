public List<List<Integer>> levelOrder(TreeNode root) {
   if (root == null) {
       return new ArrayList<>();
   }
   
   List<List<Integer>> result = new ArrayList<>();
   Queue<TreeNode> queue = new LinkedList<>();
   queue.add(root);
   
   while (!queue.isEmpty()) {
       List<Integer> level = new ArrayList<>();
       int levelSize = queue.size();
       
       for (int i = 0; i < levelSize; i++) {
           TreeNode node = queue.poll();
           level.add(node.val);
           
           if (node.left != null) {
               queue.add(node.left);
           }
           if (node.right != null) {
               queue.add(node.right);
           }
       }
       
       result.add(level);
   }
   
   return result;
}