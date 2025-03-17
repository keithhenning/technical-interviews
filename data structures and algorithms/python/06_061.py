import unittest

class NQueens:
   @staticmethod
   def solve_n_queens(n):
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

         for i in range(n):
            # Check if queen can be placed
            if is_safe(board, i, col):
               # Place the queen
               board[i][col] = 1

               # Recur to place rest of the queens
               if solve_util(board, col + 1):
                  return True
               
               # Remove queen if no solution found
               board[i][col] = 0
         
         # No solution with current configuration
         return False

      # Initialize board
      board = [[0 for x in range(n)] for y in range(n)]
      
      if not solve_util(board, 0):
         return None
         
      return board

   @staticmethod
   def format_board(board):
      # Return None if no solution
      if board is None:
         return None
      # Convert board to readable format
      return [''.join(['Q' if cell == 1 else '.' 
                     for cell in row]) 
             for row in board]

class TestNQueens(unittest.TestCase):
   def setUp(self):
      # Initialize solver
      self.solver = NQueens()

   def test_1x1_board(self):
      """Test case for 1x1 board - should have one solution"""
      result = self.solver.solve_n_queens(1)
      self.assertIsNotNone(result)
      self.assertEqual(len(result), 1)
      self.assertEqual(result[0][0], 1)

   def test_2x2_board(self):
      """Test case for 2x2 board - should have no solution"""
      result = self.solver.solve_n_queens(2)
      self.assertIsNone(result)

   def test_3x3_board(self):
      """Test case for 3x3 board - should have no solution"""
      result = self.solver.solve_n_queens(3)
      self.assertIsNone(result)

   def test_4x4_board(self):
      """Test case for 4x4 board - should have a solution"""
      result = self.solver.solve_n_queens(4)
      self.assertIsNotNone(result)
      formatted = self.solver.format_board(result)
      # One of the possible solutions for 4x4
      self.assertEqual(len(formatted), 4)
      self.assertEqual(sum(row.count('Q') 
                         for row in formatted), 4)

   def test_8x8_board(self):
      """Test case for 8x8 board - should have a solution"""
      result = self.solver.solve_n_queens(8)
      self.assertIsNotNone(result)
      formatted = self.solver.format_board(result)
      self.assertEqual(len(formatted), 8)
      self.assertEqual(sum(row.count('Q') 
                         for row in formatted), 8)

   def test_queen_threats(self):
      """Test that no queens threaten each other"""
      n = 4
      result = self.solver.solve_n_queens(n)
      self.assertIsNotNone(result)
      
      # Check row threats
      for row in result:
         self.assertEqual(sum(row), 1)
      
      # Check column threats
      for j in range(n):
         self.assertEqual(sum(result[i][j] 
                           for i in range(n)), 1)
      
      # Check diagonal threats
      for i in range(n):
         for j in range(n):
            if result[i][j] == 1:
               # Check diagonals from queen's position
               for k in range(1, n):
                  # Check upper-right diagonal
                  if i-k >= 0 and j+k < n:
                     self.assertEqual(result[i-k][j+k], 0)
                  # Check lower-right diagonal
                  if i+k < n and j+k < n:
                     self.assertEqual(result[i+k][j+k], 0)

def visualize_solution(board):
   """Helper function to visualize board solution"""
   if board is None:
      return "No solution exists"
   
   # Format the board
   formatted = NQueens.format_board(board)
   return '\n'.join(formatted)

if __name__ == '__main__':
   # Example usage and visualization
   print("Testing different board sizes:")
   for n in [1, 2, 3, 4, 8]:
      print(f"\nTesting {n}x{n} board:")
      solution = NQueens.solve_n_queens(n)
      print(visualize_solution(solution))
   
   # Run the unit tests
   unittest.main(argv=['first-arg-is-ignored'], 
                exit=False)