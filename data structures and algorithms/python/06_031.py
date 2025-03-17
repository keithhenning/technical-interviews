def astar_memory_efficient(grid, start, goal):
    # Store only essential information
    parent = {}
    g_score = {start: 0}
    
    # Use generator for neighbors
    def neighbor_generator(pos):
        for dx, dy in [(0, 1), (1, 0), (0, -1), (-1, 0)]:
            yield (pos[0] + dx, pos[1] + dy)