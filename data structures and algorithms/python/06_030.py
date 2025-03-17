def bidirectional_astar(grid, start, goal):
    forward_front = {start: 0}
    backward_front = {goal: 0}
    
    while forward_front and backward_front:
        # Expand both fronts
        if len(forward_front) < len(backward_front):
            current = expand_front(forward_front)
        else:
            current = expand_front(backward_front)
            
        # Check for intersection
        if current in forward_front and current in backward_front:
            return reconstruct_path(current)