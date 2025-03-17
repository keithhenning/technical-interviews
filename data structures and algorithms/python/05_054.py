def sorted_array_to_bst(nums):
    if not nums:
        return None
    
    mid = len(nums) // 2
    root = Node(nums[mid])
    
    root.left = sorted_array_to_bst(nums[:mid])
    root.right = sorted_array_to_bst(nums[mid+1:])
    
    return root