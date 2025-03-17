#include <vector>
#include <cstddef> // for nullptr

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

class Solution {
public:
    TreeNode* balanceBST(TreeNode* root) {
        // Step 1: Collect nodes in sorted order via in-order
        std::vector<int> nodes;
        inOrderTraversal(root, nodes);
        
        // Step 2: Reconstruct balanced BST
        return buildBalancedBST(nodes, 0, nodes.size() - 1);
    }
    
private:
    void inOrderTraversal(TreeNode* node, 
                         std::vector<int>& nodes) {
        if (!node) {
            return;
        }
        
        inOrderTraversal(node->left, nodes);  // Fixed: node->left
        nodes.push_back(node->val);
        inOrderTraversal(node->right, nodes); // Fixed: node->right
    }
    
    TreeNode* buildBalancedBST(
            const std::vector<int>& values, 
            int start, 
            int end) {
        if (start > end) {
            return nullptr;
        }
        
        int mid = start + (end - start) / 2; // Safer calculation
        TreeNode* node = new TreeNode(values[mid]);
        
        // Recursively build left and right subtrees
        node->left = buildBalancedBST(values, start, mid - 1);
        node->right = buildBalancedBST(values, mid + 1, end);
        
        return node;
    }
};