#include <vector>
#include <climits>
#include <algorithm>

class Solution {
public:
    int maxDiagonalSum(std::vector<std::vector<int>>& matrix) {
        if (matrix.empty() || matrix[0].empty()) {
            return 0;
        }
        
        int n = matrix.size();
        int maxSum = INT_MIN;
        
        // Check diagonals starting from top row
        for (int col = 0; col < n; col++) {
            int diagonalSum = 0;
            int r = 0, c = col;
            
            while (r < n && c < n) {
                diagonalSum += matrix[r][c];
                r++;
                c++;
            }
            
            maxSum = std::max(maxSum, diagonalSum);
        }
        
        // Check diagonals starting from leftmost column
        // Start from 1 to avoid recounting (0,0)
        for (int row = 1; row < n; row++) {
            int diagonalSum = 0;
            int r = row, c = 0;
            
            while (r < n && c < n) {
                diagonalSum += matrix[r][c];
                r++;
                c++;
            }
            
            maxSum = std::max(maxSum, diagonalSum);
        }
        
        return maxSum;
    }
};