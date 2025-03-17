def num_islands(grid):

    if not grid or not grid[0]:
        return 0
    
    rows, cols = len(grid), len(grid[0])
    count = 0
    
    # Helper function to perform DFS from a land cell
    def dfs(r, c):
        # Check if out of bounds or if cell is water
        if (r < 0 or c < 0 or r >= rows or c >= cols or 
            grid[r][c] == '0'):
            return
        
        # Mark as visited by changing to water
        grid[r][c] = '0'
        
        # Check all four directions
        dfs(r + 1, c)  # down
        dfs(r - 1, c)  # up
        dfs(r, c + 1)  # right
        dfs(r, c - 1)  # left
    
    # Iterate through each cell in the grid
    for r in range(rows):
        for c in range(cols):
            if grid[r][c] == '1':
                count += 1  # Found a new island
                dfs(r, c)   # Mark all connected land as visited
    
    return count

# Example usage
grid = [
    ["1","1","0","0","0"],
    ["1","1","0","1","0"],
    ["0","0","0","0","0"],
    ["0","0","0","1","1"]
]
print(num_islands(grid))  # 3