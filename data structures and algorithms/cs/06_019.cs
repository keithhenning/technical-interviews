// Let's create a tree showing the pre-order traversal pattern:
//       1
//      / \
//     2   5
//    / \   \
//   3   4   6
//           /
//          7

// Create our test tree
TreeNode root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(5);
root.left.left = new TreeNode(3);
root.left.right = new TreeNode(4);
root.right.right = new TreeNode(6);
root.right.right.left = new TreeNode(7);

// Initialize our DFS tree traversal object
DFSTree dfsTree = new DFSTree();

// Test both methods and compare results
List<int> recursiveResult = dfsTree.dfsRecursive(root);
List<int> iterativeResult = dfsTree.dfsIterative(root);

// Should print: [1, 2, 3, 4, 5, 6, 7]
Console.WriteLine("Recursive DFS: " + string.Join(", ", recursiveResult));
// Should print: [1, 2, 3, 4, 5, 6, 7]
Console.WriteLine("Iterative DFS: " + string.Join(", ", iterativeResult));

// Let's also test some edge cases I've learned are important:
Console.WriteLine("\nTesting edge cases:");

// Empty tree
TreeNode emptyRoot = null;
// Should print: []
Console.WriteLine("Empty tree (recursive): " + string.Join(", ", dfsTree.dfsRecursive(emptyRoot)));
// Should print: []
Console.WriteLine("Empty tree (iterative): " + string.Join(", ", dfsTree.dfsIterative(emptyRoot)));

// Single node tree
TreeNode singleNode = new TreeNode(42);
// Should print: [42]
Console.WriteLine("Single node (recursive): " + string.Join(", ", dfsTree.dfsRecursive(singleNode)));
// Should print: [42]
Console.WriteLine("Single node (iterative): " + string.Join(", ", dfsTree.dfsIterative(singleNode)));

// Linear tree (only left children)
TreeNode linearRoot = new TreeNode(1);
linearRoot.left = new TreeNode(2);
linearRoot.left.left = new TreeNode(3);
// Should print: [1, 2, 3]
Console.WriteLine("Linear tree (recursive): " + string.Join(", ", dfsTree.dfsRecursive(linearRoot)));
// Should print: [1, 2, 3]
Console.WriteLine("Linear tree (iterative): " + string.Join(", ", dfsTree.dfsIterative(linearRoot)));
