#include <vector>
#include <stack>

/**
 * A basic binary tree node implementation.
 */
class TreeNode {
public:
   int value;
   TreeNode* left;
   TreeNode* right;
   
   // Constructor
   TreeNode(int value) {
      this->value = value;
      this->left = nullptr;
      this->right = nullptr;
   }
};

/**
 * Implementation of Depth-First Search (DFS) tree 
 * traversal.
 */
class DFSTree {
public:
   /**
    * Perform recursive DFS traversal in pre-order.
    */
   std::vector<int> dfsRecursive(TreeNode* root) {
      std::vector<int> result;
      explore(root, result);
      return result;
   }
   
private:
   void explore(TreeNode* node, std::vector<int>& result) {
      if (node == nullptr) {
         return;
      }
      
      // Pre-order: Process BEFORE recursion
      result.push_back(node->value);
      
      // Go as deep as possible left
      explore(node->left, result);
      // Then go right
      explore(node->right, result);
   }
   
public:
   /**
    * Perform iterative DFS traversal in pre-order
    * using a stack.
    */
   std::vector<int> dfsIterative(TreeNode* root) {
      if (root == nullptr) {
         return std::vector<int>();
      }
      
      std::vector<int> result;
      std::stack<TreeNode*> stack;
      // Use stack to mimic recursion
      stack.push(root);
      
      while (!stack.empty()) {
         // Get last node added
         TreeNode* node = stack.top();
         stack.pop();
         result.push_back(node->value);
         
         // Add right first (so left gets processed first)
         if (node->right != nullptr) {
            stack.push(node->right);
         }
         if (node->left != nullptr) {
            stack.push(node->left);
         }
      }
      
      return result;
   }
};