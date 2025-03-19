// Dijkstra - only uses g_score
int priority = gScore.get(Arrays.toString(current));

// A* - uses f_score (g_score + heuristic)
int priority = gScore.get(Arrays.toString(current)) + heuristic(current, goal);