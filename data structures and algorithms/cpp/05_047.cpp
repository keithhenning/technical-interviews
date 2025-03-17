int get_height(Node* node) {
    if (!node) {
        return 0;
    }
    return 1 + std::max(get_height(node->left), 
                       get_height(node->right));
}