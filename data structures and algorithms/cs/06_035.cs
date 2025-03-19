// Dijkstra - only uses g_score
int priority = gScore[ArrayToString(current)];

// A* - uses f_score (g_score + heuristic)
int priority = gScore[ArrayToString(current)] + Heuristic(current, goal);
