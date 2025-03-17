def adaptive_heuristic(a, b, grid_type):
    if grid_type == "manhattan":
        return abs(a[0] - b[0]) + abs(a[1] - b[1])
    elif grid_type == "chebyshev":  # Allows diagonal movement
        return max(abs(a[0] - b[0]), abs(a[1] - b[1]))