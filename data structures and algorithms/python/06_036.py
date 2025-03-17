def get_neighbors_weighted(pos, grid):
    neighbors = []
    for dx, dy in [(0, 1), (1, 0), (0, -1), (-1, 0)]:
        new_x, new_y = pos[0] + dx, pos[1] + dy
        if valid_position(new_x, new_y, grid):
            weight = grid[new_x][new_y]  # Weight from grid
            neighbors.append(((new_x, new_y), weight))
    return neighbors