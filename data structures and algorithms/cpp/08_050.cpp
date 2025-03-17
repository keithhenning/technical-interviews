#include <cstddef> // for nullptr

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

class Solution {
public:
    TreeNode* symmetrizeTree(TreeNode* root) {
        if (!root) {
            return nullptr;
        }
        
        // Transform left and right subtrees first
        root->left = symmetrizeTree(root->left);
        root->right = symmetrizeTree(root->right);
        
        // Check if subtrees are symmetric
        if (!isSymmetric(root->left, root->right)) {
            // Not symmetric, make them symmetric
            if (root->left && !root->right) {
                // Only left child exists, mirror it
                root->right = mirrorTree(root->left);
            } else if (root->right && !root->left) {
                // Only right child exists, mirror it
                root->left = mirrorTree(root->right);
            } else {
                // Both children exist but not symmetric
                // Choose left subtree as reference and mirror it
                root->right = mirrorTree(root->left);
            }
        }
        
        return root;
    }
    
private:
    bool isSymmetric(TreeNode* left, TreeNode* right) {
        if (!left && !right) {
            return true;
        }
        if (!left || !right) {
            return false;
        }
        if (left->val != right->val) {
            return false;
        }
        
        return isSymmetric(left->left, right->right) && 
               isSymmetric(left->right, right->left);
    }
    
    TreeNode* mirrorTree(TreeNode* node) {
        if (!node) {
            return nullptr;
        }
        
        TreeNode* mirrored = new TreeNode(node->val);
        mirrored->left = mirrorTree(node->right);
        mirrored->right = mirrorTree(node->left);
        
        return mirrored;
    }
};