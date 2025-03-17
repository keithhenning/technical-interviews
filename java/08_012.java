public class NumberOfIslands {
    public static int numIslands(char[][] grid) {
        if (grid == null || grid.length == 0 || 
            grid[0].length == 0) {
            return 0;
        }
        
        int rows = grid.length;
        int cols = grid[0].length;
        int count = 0;
        
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == '1') {
                    count++;  // Found a new island
                    // Mark all connected as visited
                    dfs(grid, r, c);  
                }
            }
        }
        
        return count;
    }
    
    private static void dfs(char[][] grid, int r, int c) {
        int rows = grid.length;
        int cols = grid[0].length;
        
        // Check if out of bounds or if cell is water
        if (r < 0 || c < 0 || r >= rows || c >= cols || 
            grid[r][c] == '0') {
            return;
        }
        
        // Mark as visited by changing to water
        grid[r][c] = '0';
        
        // Check all four directions
        dfs(grid, r + 1, c);  // down
        dfs(grid, r - 1, c);  // up
        dfs(grid, r, c + 1);  // right
        dfs(grid, r, c - 1);  // left
    }
    
    public static void main(String[] args) {
        char[][] grid = {
            {'1','1','0','0','0'},
            {'1','1','0','0','0'},
            {'0','0','1','0','0'},
            {'0','0','0','1','1'}
        };
        
        System.out.println(numIslands(grid));  // 3
    }
}