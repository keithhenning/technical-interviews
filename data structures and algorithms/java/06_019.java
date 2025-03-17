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
List<Integer> recursiveResult = dfsTree.dfsRecursive(root);
List<Integer> iterativeResult = dfsTree.dfsIterative(root);

// Should print: [1, 2, 3, 4, 5, 6, 7]
System.out.println("Recursive DFS: " + recursiveResult);
// Should print: [1, 2, 3, 4, 5, 6, 7]
System.out.println("Iterative DFS: " + iterativeResult);

// Let's also test some edge cases I've learned are important:
System.out.println("\nTesting edge cases:");

// Empty tree
TreeNode emptyRoot = null;
// Should print: []
System.out.println("Empty tree (recursive): " + dfsTree.dfsRecursive(emptyRoot));
// Should print: []
System.out.println("Empty tree (iterative): " + dfsTree.dfsIterative(emptyRoot));

// Single node tree
TreeNode singleNode = new TreeNode(42);
// Should print: [42]
System.out.println("Single node (recursive): " + dfsTree.dfsRecursive(singleNode));
// Should print: [42]
System.out.println("Single node (iterative): " + dfsTree.dfsIterative(singleNode));

// Linear tree (only left children)
TreeNode linearRoot = new TreeNode(1);
linearRoot.left = new TreeNode(2);
linearRoot.left.left = new TreeNode(3);
// Should print: [1, 2, 3]
System.out.println("Linear tree (recursive): " + dfsTree.dfsRecursive(linearRoot));
// Should print: [1, 2, 3]
System.out.println("Linear tree (iterative): " + dfsTree.dfsIterative(linearRoot));