def maxKennelCompatibility(compatibility):

    n = len(compatibility)
    grid_size = int(n**0.5)
    if grid_size * grid_size != n:
        return -1  # Can't form a perfect square grid
    
    # Define adjacent positions in the grid
    def get_adjacent(i, j):
        directions = [(0, 1), (1, 0), (0, -1), (-1, 0)]
        adjacent = []
        for di, dj in directions:
            ni, nj = i + di, j + dj
            if 0 <= ni < grid_size and 0 <= nj < grid_size:
                adjacent.append((ni, nj))
        return adjacent
    
    # Convert grid position to dog index
    def pos_to_idx(i, j):
        return i * grid_size + j
    
    # Calculate compatibility between two grid positions
    def get_compatibility(pos1, pos2, assignment):
        dog1 = assignment[pos1[0]][pos1[1]]
        dog2 = assignment[pos2[0]][pos2[1]]
        if dog1 == -1 or dog2 == -1:
            return 0
        return compatibility[dog1][dog2]
    
    # Backtracking function
    def backtrack(assignment, row, col, used, current_score, 
                  best_score):
        # If we've filled the entire grid, return the score
        if row == grid_size:
            return max(current_score, best_score)
        
        # Calculate next position
        next_row, next_col = row, col + 1
        if next_col == grid_size:
            next_row, next_col = row + 1, 0
        
        # Try placing each dog at the current position
        for dog in range(n):
            if not used[dog]:
                used[dog] = True
                assignment[row][col] = dog
                
                # Calculate additional compatibility 
                # from this placement
                additional_score = 0
                for adj_row, adj_col in get_adjacent(row, col):
                    if assignment[adj_row][adj_col] != -1:
                        additional_score += compatibility[dog][
                            assignment[adj_row][adj_col]
                        ]
                
                # Recursive call
                best_score = backtrack(
                    assignment, next_row, next_col, used, 
                    current_score + additional_score, best_score
                )
                
                # Backtrack
                assignment[row][col] = -1
                used[dog] = False
        
        return best_score
    
    # Initialize grid with -1 (no dog assigned)
    assignment = [[-1 for _ in range(grid_size)] 
                 for _ in range(grid_size)]
    used = [False] * n
    
    return backtrack(assignment, 0, 0, used, 0, 0)