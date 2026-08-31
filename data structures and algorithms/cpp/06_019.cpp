#include <iostream>
#include <vector>

// Let's create a tree showing the pre-order traversal pattern:
//       1
//      / \
//     2   5
//    / \   \
//   3   4   6
//           /
//          7

// Helper to print vector
void printVector(const std::vector<int>& vec) {
   std::cout << "[";
   for (size_t i = 0; i < vec.size(); i++) {
      std::cout << vec[i];
      if (i < vec.size() - 1) {
         std::cout << ", ";
      }
   }
   std::cout << "]" << std::endl;
}

int main() {
   // Create our test tree
   TreeNode* root = new TreeNode(1);
   root->left = new TreeNode(2);
   root->right = new TreeNode(5);
   root->left->left = new TreeNode(3);
   root->left->right = new TreeNode(4);
   root->right->right = new TreeNode(6);
   root->right->right->left = new TreeNode(7);

   // Initialize our DFS tree traversal object
   DFSTree dfsTree;

   // Test both methods and compare results
   std::vector<int> recursiveResult = dfsTree.dfsRecursive(root);
   std::vector<int> iterativeResult = dfsTree.dfsIterative(root);

   // Should print: [1, 2, 3, 4, 5, 6, 7]
   std::cout << "Recursive DFS: ";
   printVector(recursiveResult);
   // Should print: [1, 2, 3, 4, 5, 6, 7]
   std::cout << "Iterative DFS: ";
   printVector(iterativeResult);

   // Let's also test some edge cases I've learned are important:
   std::cout << "\nTesting edge cases:" << std::endl;

   // Empty tree
   TreeNode* emptyRoot = nullptr;
   // Should print: []
   std::cout << "Empty tree (recursive): ";
   printVector(dfsTree.dfsRecursive(emptyRoot));
   // Should print: []
   std::cout << "Empty tree (iterative): ";
   printVector(dfsTree.dfsIterative(emptyRoot));

   // Single node tree
   TreeNode* singleNode = new TreeNode(42);
   // Should print: [42]
   std::cout << "Single node (recursive): ";
   printVector(dfsTree.dfsRecursive(singleNode));
   // Should print: [42]
   std::cout << "Single node (iterative): ";
   printVector(dfsTree.dfsIterative(singleNode));

   // Linear tree (only left children)
   TreeNode* linearRoot = new TreeNode(1);
   linearRoot->left = new TreeNode(2);
   linearRoot->left->left = new TreeNode(3);
   // Should print: [1, 2, 3]
   std::cout << "Linear tree (recursive): ";
   printVector(dfsTree.dfsRecursive(linearRoot));
   // Should print: [1, 2, 3]
   std::cout << "Linear tree (iterative): ";
   printVector(dfsTree.dfsIterative(linearRoot));

   return 0;
}
