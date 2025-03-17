#include <iostream>
#include <vector>
#include <queue>

struct TreeNode {
    int value;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : value(x), left(nullptr), right(nullptr) {}
};

class TreeBFS {
public:
    std::vector<std::vector<int>> breadthFirstSearch(
            TreeNode* root) {
        std::vector<std::vector<int>> result;
        if (!root) return result;
        
        std::queue<TreeNode*> q;
        q.push(root);
        
        while (!q.empty()) {
            int levelSize = q.size();
            std::vector<int> currentLevel;
            
            for (int i = 0; i < levelSize; i++) {
                TreeNode* current = q.front();
                q.pop();
                currentLevel.push_back(current->value);
                
                if (current->left) {
                    q.push(current->left);
                }
                if (current->right) {
                    q.push(current->right);
                }
            }
            
            result.push_back(currentLevel);
        }
        
        return result;
    }
};