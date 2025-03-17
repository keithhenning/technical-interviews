// Iterative inorder traversal
template <typename T>
struct TreeNode {
    T val;
    TreeNode* left;
    TreeNode* right;
    
    TreeNode(T x) : val(x), left(nullptr), right(nullptr) {}
};

template <typename T>
std::vector<T> inorder_iterative(TreeNode<T>* root) {
    std::vector<T> result;
    std::stack<TreeNode<T>*> stack;
    TreeNode<T>* current = root;
    
    while (current != nullptr || !stack.empty()) {
        while (current != nullptr) {
            stack.push(current);
            current = current->left;
        }
        current = stack.top();
        stack.pop();
        result.push_back(current->val);
        current = current->right;
    }
    
    return result;
}