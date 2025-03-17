def heuristic(a, b):
    # Manhattan distance - fast but may not be optimal for all cases
    return abs(a[0] - b[0]) + abs(a[1] - b[1])
    
    # Euclidean distance - more accurate for diag. but slowewr
    # return ((a[0] - b[0]) ** 2 + (a[1] - b[1]) ** 2) ** 0.5