void dfsThreeWays(TreeNode* node) {
    // Base case: return if node is null
    if (node == nullptr) {
        return;
    }
    
    // Pre-order: Process BEFORE children
    std::cout << node->value << std::endl;  // Pre-order
    dfsThreeWays(node->left);
    // In-order: Process BETWEEN children
    std::cout << node->value << std::endl;  // In-order
    dfsThreeWays(node->right);
    // Post-order: Process AFTER children
    std::cout << node->value << std::endl;  // Post-order
}