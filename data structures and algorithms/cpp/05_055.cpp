int kth_smallest(Node* root, int k) {
    // Perform inorder traversal and return the kth element
    std::vector<int> result;
    
    std::function<void(Node*)> inorder = [&](Node* node) {
        if (!node || result.size() >= k) {
            return;
        }
        inorder(node->left);
        result.push_back(node->value);
        inorder(node->right);
    };
    
    inorder(root);
    return (k <= result.size()) ? result[k-1] : -1;
}