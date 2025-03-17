def max_diagonal_sum(matrix):

    if not matrix or not matrix[0]:
        return 0
    
    n = len(matrix)
    max_sum = float('-inf')
    
    # Check diagonals starting from top row
    for col in range(n):
        diagonal_sum = 0
        r, c = 0, col
        
        while r < n and c < n:
            diagonal_sum += matrix[r][c]
            r += 1
            c += 1
        
        max_sum = max(max_sum, diagonal_sum)
    
    # Check diagonals starting from leftmost column
    # Start from 1 to avoid recounting (0,0)
    for row in range(1, n):  
        diagonal_sum = 0
        r, c = row, 0
        
        while r < n and c < n:
            diagonal_sum += matrix[r][c]
            r += 1
            c += 1
        
        max_sum = max(max_sum, diagonal_sum)
    
    return max_sum