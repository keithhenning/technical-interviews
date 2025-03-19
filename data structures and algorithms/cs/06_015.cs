// Test empty tree
TreeNode emptyRoot = null;
// Should print: []
Console.WriteLine("Empty tree: " + BreadthFirstSearch(emptyRoot));

// Test single node tree
TreeNode singleNode = new TreeNode(42);
// Should print: [[42]]
Console.WriteLine("Single node tree: " + BreadthFirstSearch(singleNode));
