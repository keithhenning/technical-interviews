void dfs_three_ways(TreeNode* node) {
    if (!node) {
        return;
    }
    
    // Pre-order: Process BEFORE children
    std::cout << node->value << std::endl;  // Pre-order
    dfs_three_ways(node->left);
    // In-order: Process BETWEEN children
    std::cout << node->value << std::endl;  // In-order
    dfs_three_ways(node->right);
    // Post-order: Process AFTER children
    std::cout << node->value << std::endl;  // Post-order
}