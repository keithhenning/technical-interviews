static std::vector<std::pair<std::vector<int>, int>> 
        getNeighborsWeighted(
            const std::vector<int>& pos,
            const std::vector<std::vector<int>>& grid) {
    
    // Vector to store neighbors with their weights
    std::vector<std::pair<std::vector<int>, int>> neighbors;
    
    // Check in all four directions
    const int directions[4][2] = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
    for (const auto& dir : directions) {
        int newX = pos[0] + dir[0];
        int newY = pos[1] + dir[1];
        
        // Add neighbor if position is valid
        if (validPosition(newX, newY, grid)) {
            // Weight from grid
            int weight = grid[newX][newY];
            neighbors.push_back({
                {newX, newY}, weight
            });
        }
    }
    
    return neighbors;
}