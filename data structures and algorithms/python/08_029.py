def can_complete_circuit(matrix, start_row, start_col):
  if matrix[start_row][start_col] == 1:
     return False  # Invalid starting position
  
  rows, cols = len(matrix), len(matrix[0])
  directions = [(0, 1), (1, 0), (0, -1), (-1, 0)]  # r,d,l,u
  visited = set()
  
  def dfs(row, col, path_length):
     # If we've returned to start after visiting 3+ cells
     if ((row, col) == (start_row, start_col) and 
         path_length >= 3):
        return True
     
     visited.add((row, col))
     
     for dr, dc in directions:
        new_row, new_col = row + dr, col + dc
        
        # Check if new position is valid and not visited
        if ((0 <= new_row < rows and 
             0 <= new_col < cols and 
             matrix[new_row][new_col] == 0 and 
             (new_row, new_col) not in visited) or 
            ((new_row, new_col) == (start_row, start_col) and 
             path_length >= 3)):
           
           if dfs(new_row, new_col, path_length + 1):
              return True
     
     # Backtrack
     visited.remove((row, col))
     return False
  
  return dfs(start_row, start_col, 0)

# Test case
matrix = [
  [0, 1, 0, 0],
  [0, 0, 0, 1],
  [1, 1, 0, 0],
  [0, 0, 0, 0]
]
print(can_complete_circuit(matrix, 0, 0))  # Should return True