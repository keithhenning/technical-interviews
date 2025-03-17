def maxProductPath(grid):

    if not grid or not grid[0]:
        return 0
    
    rows, cols = len(grid), len(grid[0])
    max_dp = [[0 for _ in range(cols)] for _ in range(rows)]
    min_dp = [[0 for _ in range(cols)] for _ in range(rows)]
    
    # Initialize the first cell
    max_dp[0][0] = min_dp[0][0] = grid[0][0]
    
    # Initialize first row
    for j in range(1, cols):
        max_dp[0][j] = max_dp[0][j-1] * grid[0][j]
        min_dp[0][j] = min_dp[0][j-1] * grid[0][j]
    
    # Initialize first column
    for i in range(1, rows):
        max_dp[i][0] = max_dp[i-1][0] * grid[i][0]
        min_dp[i][0] = min_dp[i-1][0] * grid[i][0]
    
    # Fill the dp arrays
    for i in range(1, rows):
        for j in range(1, cols):
            if grid[i][j] >= 0:
                max_dp[i][j] = max(
                    max_dp[i-1][j], max_dp[i][j-1]
                ) * grid[i][j]
                min_dp[i][j] = min(
                    min_dp[i-1][j], min_dp[i][j-1]
                ) * grid[i][j]
            else:
                max_dp[i][j] = min(
                    min_dp[i-1][j], min_dp[i][j-1]
                ) * grid[i][j]
                min_dp[i][j] = max(
                    max_dp[i-1][j], max_dp[i][j-1]
                ) * grid[i][j]
    
    return max_dp[rows-1][cols-1]