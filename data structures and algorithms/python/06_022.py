def dfs_with_yield(node):
    if not node:
        return
    yield node.value
    yield from dfs_with_yield(node.left)
    yield from dfs_with_yield(node.right)