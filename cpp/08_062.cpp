#include <vector>
using namespace std;

class Solution {
public:
    // Count number of islands in a grid
    int numIslands(vector<vector<char>>& grid) {
        // Check if grid is empty
        if (grid.empty() || grid[0].empty()) {
            return 0;
        }
        
        int rows = grid.size();
        int cols = grid[0].size();
        int count = 0;
        
        // Traverse the grid
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                // If land is found, run DFS to mark island
                if (grid[i][j] == '1') {
                    count++;
                    dfs(grid, i, j, rows, cols);
                }
            }
        }
        
        return count;
    }
    
private:
    // Run DFS to mark connected land cells
    void dfs(vector<vector<char>>& grid, int i, int j, 
            int rows, int cols) {
        // Check boundaries and if cell is water or visited
        if (i < 0 || i >= rows || j < 0 || j >= cols || 
            grid[i][j] == '0') {
            return;
        }
        
        // Mark as visited
        grid[i][j] = '0';
        
        // Explore all four directions
        dfs(grid, i+1, j, rows, cols);
        dfs(grid, i-1, j, rows, cols);
        dfs(grid, i, j+1, rows, cols);
        dfs(grid, i, j-1, rows, cols);
    }
};