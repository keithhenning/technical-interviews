#include <iostream>
#include <vector>
#include <string>
#include <cassert>

class NQueens {
public:
    static std::vector<std::vector<int>> solveNQueens(int n) {
        std::vector<std::vector<int>> board(n, 
                                      std::vector<int>(n, 0));
        
        if (!solveUtil(board, 0, n)) {
            return std::vector<std::vector<int>>();
        }
        
        return board;
    }

    static std::vector<std::string> formatBoard(
        const std::vector<std::vector<int>>& board) {
        
        if (board.empty()) {
            return std::vector<std::string>();
        }
        
        int n = board.size();
        std::vector<std::string> formatted(n);
        
        for (int i = 0; i < n; i++) {
            std::string row;
            for (int j = 0; j < n; j++) {
                row += (board[i][j] == 1) ? 'Q' : '.';
            }
            formatted[i] = row;
        }
        
        return formatted;
    }

private:
    static bool isSafe(const std::vector<std::vector<int>>& board,
                     int row, int col, int n) {
        // Check row on left side
        for (int j = 0; j < col; j++) {
            if (board[row][j] == 1) {
                return false;
            }
        }
        
        // Check upper diagonal on left side
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--) {
            if (board[i][j] == 1) {
                return false;
            }
        }
        
        // Check lower diagonal on left side
        for (int i = row, j = col; i < n && j >= 0; i++, j--) {
            if (board[i][j] == 1) {
                return false;
            }
        }
        
        return true;
    }

    static bool solveUtil(std::vector<std::vector<int>>& board,
                        int col, int n) {
        if (col >= n) {
            return true;
        }

        for (int i = 0; i < n; i++) {
            // Check if queen can be placed
            if (isSafe(board, i, col, n)) {
                board[i][col] = 1;

                // Recur to place rest of the queens
                if (solveUtil(board, col + 1, n)) {
                    return true;
                }
                
                // If placing queen doesn't lead to solution,
                // remove queen from board
                board[i][col] = 0;
            }
        }
        
        return false;
    }
};

class TestNQueens {
public:
    static void runTests() {
        test1x1Board();
        test2x2Board();
        test3x3Board();
        test4x4Board();
        test8x8Board();
        testQueenThreats();
        
        std::cout << "All tests passed!" << std::endl;
    }

private:
    static void test1x1Board() {
        // Test case for 1x1 board - should have one solution
        auto result = NQueens::solveNQueens(1);
        assert(!result.empty());
        assert(result.size() == 1);
        assert(result[0][0] == 1);
        std::cout << "1x1 board test passed" << std::endl;
    }

    static void test2x2Board() {
        // Test case for 2x2 board - should have no solution
        auto result = NQueens::solveNQueens(2);
        assert(result.empty());
        std::cout << "2x2 board test passed" << std::endl;
    }

    static void test3x3Board() {
        // Test case for 3x3 board - should have no solution
        auto result = NQueens::solveNQueens(3);
        assert(result.empty());
        std::cout << "3x3 board test passed" << std::endl;
    }

    static void test4x4Board() {
        // Test case for 4x4 board - should have a solution
        auto result = NQueens::solveNQueens(4);
        assert(!result.empty());
        
        auto formatted = NQueens::formatBoard(result);
        assert(formatted.size() == 4);
        
        // Count queens
        int queenCount = 0;
        for (const auto& row : formatted) {
            for (char c : row) {
                if (c == 'Q') queenCount++;
            }
        }
        assert(queenCount == 4);
        
        std::cout << "4x4 board test passed" << std::endl;
    }

    static void test8x8Board() {
        // Test case for 8x8 board - should have a solution
        auto result = NQueens::solveNQueens(8);
        assert(!result.empty());
        
        auto formatted = NQueens::formatBoard(result);
        assert(formatted.size() == 8);
        
        // Count queens
        int queenCount = 0;
        for (const auto& row : formatted) {
            for (char c : row) {
                if (c == 'Q') queenCount++;
            }
        }
        assert(queenCount == 8);
        
        std::cout << "8x8 board test passed" << std::endl;
    }

    static void testQueenThreats() {
        // Test that no queens threaten each other in the solution
        int n = 4;
        auto result = NQueens::solveNQueens(n);
        assert(!result.empty());
        
        // Check row threats
        for (int i = 0; i < n; i++) {
            int sum = 0;
            for (int j = 0; j < n; j++) {
                sum += result[i][j];
            }
            assert(sum == 1);
        }
        
        // Check column threats
        for (int j = 0; j < n; j++) {
            int sum = 0;
            for (int i = 0; i < n; i++) {
                sum += result[i][j];
            }
            assert(sum == 1);
        }
        
        // Check diagonal threats
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (result[i][j] == 1) {
                    // Check diagonals from this queen's position
                    for (int k = 1; k < n; k++) {
                        // Check upper-right diagonal
                        if (i-k >= 0 && j+k < n) {
                            assert(result[i-k][j+k] == 0);
                        }
                        // Check lower-right diagonal
                        if (i+k < n && j+k < n) {
                            assert(result[i+k][j+k] == 0);
                        }
                    }
                }
            }
        }
        
        std::cout << "Queen threats test passed" << std::endl;
    }
};

void visualizeSolution(const std::vector<std::vector<int>>& board) {
    // Helper function to visualize the board solution
    if (board.empty()) {
        std::cout << "No solution exists" << std::endl;
        return;
    }
    
    auto formatted = NQueens::formatBoard(board);
    for (const auto& row : formatted) {
        std::cout << row << std::endl;
    }
}

int main() {
    std::cout << "Testing different board sizes:" << std::endl;
    
    // Example usage and visualization
    int testSizes[] = {1, 2, 3, 4, 8};
    for (int n : testSizes) {
        std::cout << "\nTesting " << n << "x" << n << " board:"
                  << std::endl;
        auto solution = NQueens::solveNQueens(n);
        visualizeSolution(solution);
    }
    
    // Run the unit tests
    TestNQueens::runTests();
    
    return 0;
}