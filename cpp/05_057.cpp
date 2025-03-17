Node* sorted_array_to_bst(
    const std::vector<int>& nums, nt start = 0, 
    int end = -1) {
        if (end == -1) end = nums.size() - 1;
        if (start > end) {
        return nullptr;
    }
    
    int mid = start + (end - start) / 2;
    Node* root = new Node(nums[mid]);
    
    root->left = sorted_array_to_bst(nums, start, mid - 1);
    root->right = sorted_array_to_bst(nums, mid + 1, end);
    
    return root;
}