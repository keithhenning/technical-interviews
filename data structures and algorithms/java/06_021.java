public void dfsThreeWays(TreeNode node) {
   // Base case: return if node is null
   if (node == null) {
       return;
   }
   
   // Pre-order: Process BEFORE children
   System.out.println(node.value);  // Pre-order
   dfsThreeWays(node.left);
   // In-order: Process BETWEEN children
   System.out.println(node.value);  // In-order
   dfsThreeWays(node.right);
   // Post-order: Process AFTER children
   System.out.println(node.value);  // Post-order
}