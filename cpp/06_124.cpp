// Define move direction constants
const int DIAGONAL_MOVES[4][2] = {
    {1, 1}, {1, -1}, {-1, 1}, {-1, -1}
};
const int STRAIGHT_MOVES[4][2] = {
    {0, 1}, {1, 0}, {0, -1}, {-1, 0}
};

static std::vector<std::pair<std::vector<int>, double>> 
getNeighborsDiagonal(
    const std::vector<int>& pos,
    const std::vector<std::vector<int>>& grid) {
    
    // Vector to store neighbors with their movement costs
    std::vector<std::pair<std::vector<int>, double>> neighbors;
    
    // Process diagonal moves
    for (const auto& dir : DIAGONAL_MOVES) {
        int newX = pos[0] + dir[0];
        int newY = pos[1] + dir[1];
        
        // Diagonal cost typically &#x221a;2 &#x2248; 1.414
        double cost = 1.414;
        
        if (validPosition(newX, newY, grid)) {
            neighbors.push_back({
                {newX, newY}, cost
            });
        }
    }
    
    // Process straight moves
    for (const auto& dir : STRAIGHT_MOVES) {
        int newX = pos[0] + dir[0];
        int newY = pos[1] + dir[1];
        
        // Straight move cost
        double cost = 1.0;
        
        if (validPosition(newX, newY, grid)) {
            neighbors.push_back({
                {newX, newY}, cost
            });
        }
    }
    
    return neighbors;
}