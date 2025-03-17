def lowest_common_ancestor(root, p, q):
    if p.key < root.key and q.key < root.key:
        return lowest_common_ancestor(root.left, p, q)
    elif p.key > root.key and q.key > root.key:
        return lowest_common_ancestor(root.right, p, q)
    else:
        return root