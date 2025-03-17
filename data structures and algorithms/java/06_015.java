// Test empty tree
TreeNode emptyRoot = null;
// Should print: []
System.out.println("Empty tree: " + breadthFirstSearch(emptyRoot));  

// Test single node tree
TreeNode singleNode = new TreeNode(42);
// Should print: [[42]]
System.out.println("Single node tree: " + breadthFirstSearch(singleNode));