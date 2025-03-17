#include <iostream>
#include <vector>

int numIslands(std::vector<std::vector<char>>& grid) {
    if (grid.empty() || grid[0].empty()) {
        return 0;
    }
    
    int rows = grid.size();
    int cols = grid[0].size();
    int count = 0;
    
    // Helper function to perform DFS from a land cell
    std::function<void(int, int)> dfs = [&](int r, int c) {
        // Check if out of bounds or if cell is water
        if (r < 0 || c < 0 || r >= rows || c >= cols || 
            grid[r][c] == '0') {
            return;
        }
        
        // Mark as visited by changing to water
        grid[r][c] = '0';
        
        // Check all four directions
        dfs(r + 1, c);  // down
        dfs(r - 1, c);  // up
        dfs(r, c + 1);  // right
        dfs(r, c - 1);  // left
    };
    
    // Iterate through each cell in the grid
    for (int r = 0; r < rows; r++) {
        for (int c = 0; c < cols; c++) {
            if (grid[r][c] == '1') {
                count++;  // Found a new island
                dfs(r, c);  // Mark all connected land as visited
            }
        }
    }
    
    return count;
}

int main() {
    std::vector<std::vector<char>> grid = {
        {'1','1','0','0','0'},
        {'1','1','0','0','0'},
        {'0','0','1','0','0'},
        {'0','0','0','1','1'}
    };
    
    std::cout << numIslands(grid) << std::endl;  // 3
    return 0;
}