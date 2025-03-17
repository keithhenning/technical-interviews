#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    // Finds maximum product path in a grid
    int maxProductPath(vector<vector<int>>& grid) {
        // Check if grid is empty
        if (grid.empty() || grid[0].empty()) {
            return 0;
        }
        
        int rows = grid.size();
        int cols = grid[0].size();
        // DP arrays for max and min products
        vector<vector<long long>> maxDp(rows, 
                                vector<long long>(cols, 0));
        vector<vector<long long>> minDp(rows, 
                                vector<long long>(cols, 0));
        
        // Initialize the first cell
        maxDp[0][0] = minDp[0][0] = grid[0][0];
        
        // Initialize first row
        for (int j = 1; j < cols; j++) {
            maxDp[0][j] = maxDp[0][j-1] * grid[0][j];
            minDp[0][j] = minDp[0][j-1] * grid[0][j];
        }
        
        // Initialize first column
        for (int i = 1; i < rows; i++) {
            maxDp[i][0] = maxDp[i-1][0] * grid[i][0];
            minDp[i][0] = minDp[i-1][0] * grid[i][0];
        }
        
        // Fill the dp arrays
        for (int i = 1; i < rows; i++) {
            for (int j = 1; j < cols; j++) {
                // For positive or zero values
                if (grid[i][j] >= 0) {
                    maxDp[i][j] = max(maxDp[i-1][j], 
                                    maxDp[i][j-1]) * grid[i][j];
                    minDp[i][j] = min(minDp[i-1][j], 
                                    minDp[i][j-1]) * grid[i][j];
                } 
                // For negative values
                else {
                    maxDp[i][j] = min(minDp[i-1][j], 
                                    minDp[i][j-1]) * grid[i][j];
                    minDp[i][j] = max(maxDp[i-1][j], 
                                    maxDp[i][j-1]) * grid[i][j];
                }
            }
        }
        
        // Return the maximum product at the bottom-right cell
        return maxDp[rows-1][cols-1];
    }
};