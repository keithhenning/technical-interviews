/**
* Let's create a tree that looks like this:
*       1
*      / \
*     2   3
*    / \   \
*   4   5   6
*  /
* 7
*/

// Create nodes and build the tree
TreeNode root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(3);
root.left.left = new TreeNode(4);
root.left.right = new TreeNode(5);
root.right.right = new TreeNode(6);
root.left.left.left = new TreeNode(7);

// Test the breadth-first search
List<List<Integer>> result = breadthFirstSearch(root);
System.out.println("BFS result (level by level): " + result);