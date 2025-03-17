std::vector<int> inorder_traversal(Node* root) {
    if (!root) {
        return {};
    }
    
    std::vector<int> result;
    // Left, Root, Right
    std::vector<int> left = inorder_traversal(root->left);
    result.insert(result.end(), left.begin(), left.end());
    
    result.push_back(root->value);
    
    std::vector<int> right = inorder_traversal(root->right);
    result.insert(result.end(), right.begin(), right.end());
    
    return result;
}