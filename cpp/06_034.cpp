// Helper function to get string key
std::string posToString(const std::vector<int>& pos) {
    return std::to_string(pos[0]) + "," + std::to_string(pos[1]);
}

// Dijkstra - only uses g_score
int priority = gScore[posToString(current)];

// A* - uses f_score (g_score + heuristic)
int priority = gScore[posToString(current)] + 
               heuristic(current, goal);