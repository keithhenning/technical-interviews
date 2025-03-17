#include <iostream>
/**
 * Solution class for solving the N-Queens problem
 * 
 * The N-Queens problem asks how to place N chess queens on an
 * N×N chessboard so that no two queens threaten each other.
 */
class Solution {
private:
    /**
     * Check if placing a queen at position (row, col) is safe.
     * 
     * @param board Current state of the chessboard
     * @param row Row to check
     * @param col Column to check
     * @param n Size of the board
     * @return True if position is safe, False otherwise
     */
    bool isSafe(vector<string>& board, int row, int col, int n) {
        // Check row on left side
        // We only need to check left side because we haven't placed
        // any queens to the right yet
        for(int j = 0; j < col; j++)
            if(board[row][j] == 'Q')
                return false;
        
        // Check upper diagonal on left side
        // Move diagonally up and left until board boundary
        for(int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if(board[i][j] == 'Q')
                return false;
        
        // Check lower diagonal on left side
        // Move diagonally down and left until board boundary
        for(int i = row, j = col; i < n && j >= 0; i++, j--)
            if(board[i][j] == 'Q')
                return false;
            
        return true;
    }
    
    /**
     * Recursive utility function to solve N-Queens problem
     * using backtracking.
     *
     * @param board Current state of the chessboard
     * @param col Current column to place a queen
     * @param n Size of the board
     * @return True if solution found, False otherwise
     */
    bool solve(vector<string>& board, int col, int n) {
        // Base case: If all queens are placed (all columns filled)
        // we've found a valid solution
        if(col >= n)
            return true;
            
        // Try placing queen in each row of the current column
        for(int i = 0; i < n; i++) {
            // Check if queen can be placed at board[i][col]
            if(isSafe(board, i, col, n)) {
                // Place the queen at this position
                board[i][col] = 'Q';
                
                // Recursively place queens in remaining columns
                if(solve(board, col + 1, n))
                    return true;
                    
                // If placing queen doesn't lead to a solution
                // remove the queen (backtrack) and try next row
                board[i][col] = '.';  // Backtrack
            }
        }
        // If no solution possible with current board state
        return false;
    }

public:
    /**
     * Public method to solve the N-Queens problem
     * 
     * @param n The size of the board and number of queens
     * @return Board representation with queens ('Q') placed in
     *         a valid solution
     */
    vector<string> solveNQueens(int n) {
        // Initialize empty chessboard of size n×n with all '.'
        vector<string> board(n, string(n, '.'));
        // Start solving from leftmost column (column 0)
        solve(board, 0, n);
        // Return the solution board
        return board;
    }
};