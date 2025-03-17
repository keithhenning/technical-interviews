// Iterative inorder example
public List<Integer> inorderIterative(TreeNode root) {
   List<Integer> result = new ArrayList<>();
   Stack<TreeNode> stack = new Stack<>();
   TreeNode current = root;
   
   while (current != null || !stack.isEmpty()) {
       while (current != null) {
           stack.push(current);
           current = current.left;
       }
       current = stack.pop();
       result.add(current.val);
       current = current.right;
   }
   
   return result;
}