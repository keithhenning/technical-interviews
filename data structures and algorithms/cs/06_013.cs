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
root.Left = new TreeNode(2);
root.Right = new TreeNode(3);
root.Left.Left = new TreeNode(4);
root.Left.Right = new TreeNode(5);
root.Right.Right = new TreeNode(6);
root.Left.Left.Left = new TreeNode(7);

// Test the breadth-first search
List<List<int>> result = BreadthFirstSearch(root);
Console.WriteLine("BFS result (level by level): " + result);
