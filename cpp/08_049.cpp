#include <vector>
#include <algorithm>

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

class Solution {
public:
    bool matchingPath(TreeNode* root1, TreeNode* root2) {
        std::vector<std::vector<int>> paths1, paths2;
        std::vector<int> currentPath;
        
        collectPaths(root1, currentPath, paths1);
        collectPaths(root2, currentPath, paths2);
        
        for (const auto& path1 : paths1) {
            if (std::find(paths2.begin(), paths2.end(), path1) 
                    != paths2.end()) {
                return true;
            }
        }
        
        return false;
    }
    
private:
    void collectPaths(
            TreeNode* node, 
            std::vector<int>& currentPath,
            std::vector<std::vector<int>>& allPaths) {
        
        if (!node) {
            return;
        }
        
        currentPath.push_back(node->val);
        
        if (!node->left && !node->right) {
            allPaths.push_back(currentPath);
        } else {
            collectPaths(node->left, currentPath, allPaths);
            collectPaths(node->right, currentPath, allPaths);
        }
        
        currentPath.pop_back();
    }
};