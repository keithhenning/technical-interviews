int main() {
    /**
    * Tree structure:
    *       1
    *      / \
    *     2   3
    *    / \   \
    *   4   5   6
    *  /
    * 7
    */
    
    // Create nodes and build the tree
    TreeNode* root = new TreeNode(1);
    root->left = new TreeNode(2);
    root->right = new TreeNode(3);
    root->left->left = new TreeNode(4);
    root->left->right = new TreeNode(5);
    root->right->right = new TreeNode(6);
    root->left->left->left = new TreeNode(7);
    
    // Test the breadth-first search
    TreeBFS bfs;
    std::vector<std::vector<int>> result = 
        bfs.breadthFirstSearch(root);
    
    // Print the result
    std::cout << "BFS result (level by level): ";
    for (const auto& level : result) {
        std::cout << "[";
        for (size_t i = 0; i < level.size(); i++) {
            std::cout << level[i];
            if (i < level.size() - 1) std::cout << ", ";
        }
        std::cout << "] ";
    }
    std::cout << std::endl;
    
    // Clean up memory
    delete root->left->left->left;
    delete root->left->left;
    delete root->left->right;
    delete root->right->right;
    delete root->left;
    delete root->right;
    delete root;
    
    return 0;
}