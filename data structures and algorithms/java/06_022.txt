public Iterator<Integer> dfsWithYield(TreeNode node) {
   // Create and return an Iterator implementation
   return new Iterator<Integer>() {
       // Stack to track traversal state
       private Stack<Object> stack = new Stack<>();
       
       {
           // Initialize with the root node
           if (node != null) {
               stack.push(node);
           }
       }
       
       @Override
       public boolean hasNext() {
           return !stack.isEmpty();
       }
       
       @Override
       public Integer next() {
           // Process next item from stack
           while (!stack.isEmpty()) {
               Object current = stack.pop();
               
               // If current is a node, push its value and children
               if (current instanceof TreeNode) {
                   TreeNode currentNode = (TreeNode) current;
                   
                   // Push right child first (LIFO)
                   if (currentNode.right != null) {
                       stack.push(currentNode.right);
                   }
                   
                   // Push left child
                   if (currentNode.left != null) {
                       stack.push(currentNode.left);
                   }
                   
                   // Push the value to return
                   stack.push(currentNode.value);
               } else {
                   // Return the value
                   return (Integer) current;
               }
           }
           throw new NoSuchElementException();
       }
   };
}