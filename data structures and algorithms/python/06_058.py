def solve_n_queens(n):
  # Tests if queen location violates rules
  def is_safe(board, row, col):
     # Check row on left side
     for j in range(col):
        if board[row][j] == 1:
           return False
           
     # Check upper diagonal on left side
     for i, j in zip(range(row, -1, -1), 
                    range(col, -1, -1)):
        if board[i][j] == 1:
           return False
           
     # Check lower diagonal on left side
     for i, j in zip(range(row, n, 1), 
                    range(col, -1, -1)):
        if board[i][j] == 1:
           return False
           
     return True
     
  def solve_util(board, col):
     # Base case: all queens placed
     if col >= n:
        return True
        
     # Try placing queen in each row of current column
     for i in range(n):
        # Check if queen can be placed
        if is_safe(board, i, col):
           # Place the queen
           board[i][col] = 1
           
           # Recur to place rest of queens
           if solve_util(board, col + 1):
              return True
              
           # Backtrack if no solution found
           board[i][col] = 0
     
     # No solution with current configuration
     return False
     
  # Initialize empty chessboard
  board = [[0 for x in range(n)] for y in range(n)]
  
  # Start solving from leftmost column
  if solve_util(board, 0) == False:
     print("Solution does not exist")
     return False
     
  # Return solution
  return board
  
result = solve_n_queens(4)
print(result)