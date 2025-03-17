int getTreeDepth(TreeNode* root) {
    if (root == nullptr) {
        return 0;
    }
    
    int depth = 0;
    std::queue<TreeNode*> queue;
    queue.push(root);
    
    while (!queue.empty()) {
        depth += 1;
        int levelSize = queue.size();
        
        for (int i = 0; i < levelSize; i++) {
            TreeNode* node = queue.front();
            queue.pop();
            if (node->left != nullptr) queue.push(node->left);
            if (node->right != nullptr) queue.push(node->right);
        }
    }
    
    return depth;
}