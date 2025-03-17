def compare_positions(pos1, pos2, goal):
    f1 = f_score[pos1]
    f2 = f_score[pos2]
    
    if f1 == f2:
        # Prefer positions closer to goal
        h1 = heuristic(pos1, goal)
        h2 = heuristic(pos2, goal)
        return h1 < h2
    
    return f1 < f2