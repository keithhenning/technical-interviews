def identify_jump_point(node, direction, grid):
    # Skip straight lines until finding a turn
    x, y = node
    dx, dy = direction
    
    while valid_position(x + dx, y + dy, grid):
        x += dx
        y += dy
        
        if has_forced_neighbor(x, y, direction, grid):
            return (x, y)
    
    return None