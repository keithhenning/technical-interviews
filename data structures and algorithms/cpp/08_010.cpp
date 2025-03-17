#include <iostream>
#include <vector>
#include <queue>

// Definition for a binary tree node
struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

std::vector<std::vector<int>> levelOrder(TreeNode* root) {
    std::vector<std::vector<int>> result;
    if (root == nullptr) return result;
    
    std::queue<TreeNode*> queue;
    queue.push(root);
    
    while (!queue.empty()) {
        int levelSize = queue.size();
        std::vector<int> currentLevel;
        
        for (int i = 0; i < levelSize; i++) {
            TreeNode* node = queue.front();
            queue.pop();
            currentLevel.push_back(node->val);
            
            if (node->left) queue.push(node->left);
            if (node->right) queue.push(node->right);
        }
        
        result.push_back(currentLevel);
    }
    
    return result;
}

// Helper function to print the result
void printResult(const std::vector<std::vector<int>>& result) {
    std::cout << "[";
    for (size_t i = 0; i < result.size(); i++) {
        std::cout << "[";
        for (size_t j = 0; j < result[i].size(); j++) {
            std::cout << result[i][j];
            if (j < result[i].size() - 1) std::cout << ",";
        }
        std::cout << "]";
        if (i < result.size() - 1) std::cout << ",";
    }
    std::cout << "]" << std::endl;
}

int main() {
    // Construct the tree [3,9,20,null,null,15,7]
    TreeNode* root = new TreeNode(3);
    root->left = new TreeNode(9);
    root->right = new TreeNode(20);
    root->right->left = new TreeNode(15);
    root->right->right = new TreeNode(7);
    
    std::vector<std::vector<int>> result = levelOrder(root);
    printResult(result);  // [[3],[9,20],[15,7]]
    
    return 0;
}