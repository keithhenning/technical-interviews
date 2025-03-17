DIAGONAL_MOVES = [(1, 1), (1, -1), (-1, 1), (-1, -1)]
STRAIGHT_MOVES = [(0, 1), (1, 0), (0, -1), (-1, 0)]

def get_neighbors_diagonal(pos, grid):
    neighbors = []
    for dx, dy in DIAGONAL_MOVES + STRAIGHT_MOVES:
        new_x, new_y = pos[0] + dx, pos[1] + dy
        # Diagonal cost typically &#x221a;2 &#x2248; 1.414
        cost = 1.414 if dx != 0 and dy != 0 else 1
        if valid_position(new_x, new_y, grid):
            neighbors.append(((new_x, new_y), cost))
    return neighbors