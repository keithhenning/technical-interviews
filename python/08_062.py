def numIslands(grid):

    if not grid or not grid[0]:
        return 0
    
    rows, cols = len(grid), len(grid[0])
    count = 0
    
    def dfs(i, j):
        if (i < 0 or i >= rows or j < 0 or j >= cols or
            grid[i][j] == '0' or grid[i][j] == '2'):
            return
        
        # Mark as visited
        grid[i][j] = '0'
        
        # Explore all four directions
        dfs(i+1, j)
        dfs(i-1, j)
        dfs(i, j+1)
        dfs(i, j-1)
    
    for i in range(rows):
        for j in range(cols):
            if grid[i][j] == '1':
                count += 1
                dfs(i, j)
    
    return count