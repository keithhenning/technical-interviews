int max_depth(Node* root) {
    if (!root) {
        return 0;
    }
    return 1 + std::max(
        max_depth(root->left), 
        max_depth(root->right)
    );
}