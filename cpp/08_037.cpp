#include <vector>
#include <unordered_set>

bool isValidXSudoku(std::vector<std::vector<int>>& board) {
    std::vector<std::unordered_set<int>> rows(9);
    std::vector<std::unordered_set<int>> cols(9);
    std::vector<std::unordered_set<int>> boxes(9);
    std::unordered_set<int> mainDiag;
    std::unordered_set<int> antiDiag;
    
    for (int i = 0; i < 9; i++) {
        for (int j = 0; j < 9; j++) {
            int num = board[i][j];
            if (num == 0) continue;
            
            // Check row
            if (rows[i].count(num)) return false;
            rows[i].insert(num);
            
            // Check column
            if (cols[j].count(num)) return false;
            cols[j].insert(num);
            
            // Check 3x3 box
            int boxIdx = (i / 3) * 3 + j / 3;
            if (boxes[boxIdx].count(num)) return false;
            boxes[boxIdx].insert(num);
            
            // Check main diagonal
            if (i == j) {
                if (mainDiag.count(num)) return false;
                mainDiag.insert(num);
            }
            
            // Check anti-diagonal
            if (i + j == 8) {
                if (antiDiag.count(num)) return false;
                antiDiag.insert(num);
            }
        }
    }
    
    return true;
}