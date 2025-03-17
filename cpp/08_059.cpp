#include <vector>
#include <string>
#include <queue>
#include <unordered_set>
#include <algorithm>

using namespace std;

int minimumStepsToCollectKeys(vector<string>& maze) {
    int rows = maze.size();
    int cols = maze[0].size();
    
    // Find the starting position and count keys
    int startRow = 0, startCol = 0;
    vector<char> keys;
    
    for (int r = 0; r < rows; r++) {
        for (int c = 0; c < cols; c++) {
            if (maze[r][c] == 'S') {
                startRow = r;
                startCol = c;
            } else if ('a' <= maze[r][c] && maze[r][c] <= 'z') {
                keys.push_back(maze[r][c]);
            }
        }
    }
    
    // Sort keys to ensure alphabetical order
    sort(keys.begin(), keys.end());
    
    // Directions for movement: up, right, down, left
    vector<pair<int, int>> directions = {
        {-1, 0}, {0, 1}, {1, 0}, {0, -1}
    };
    
    // Current position
    int currRow = startRow, currCol = startCol;
    int totalSteps = 0;
    unordered_set<char> collectedKeys;
    
    // Collect each key in alphabetical order
    for (char key : keys) {
        // BFS to find the shortest path to the current key
        queue<vector<int>> q;
        q.push({currRow, currCol, 0});  // {row, col, steps}
        unordered_set<string> visited;
        visited.insert(to_string(currRow) + "," + 
                      to_string(currCol));
        bool found = false;
        
        while (!q.empty() && !found) {
            vector<int> curr = q.front();
            q.pop();
            int r = curr[0], c = curr[1], steps = curr[2];
            
            // Check if we found the key
            if (maze[r][c] == key) {
                totalSteps += steps;
                currRow = r;
                currCol = c;
                collectedKeys.insert(key);
                found = true;
                break;
            }
            
            // Try all four directions
            for (auto& dir : directions) {
                int nr = r + dir.first, nc = c + dir.second;
                
                // Check if the new position is valid
                if (0 <= nr && nr < rows && 0 <= nc && nc < cols && 
                    maze[nr][nc] != '#' && 
                    visited.find(to_string(nr) + "," + 
                               to_string(nc)) == visited.end()) {
                    
                    // Check if it's a door and we have the key
                    char cell = maze[nr][nc];
                    if ('A' <= cell && cell <= 'Z') {
                        char keyNeeded = tolower(cell);
                        if (collectedKeys.find(keyNeeded) == 
                            collectedKeys.end()) {
                            continue;
                        }
                    }
                    
                    q.push({nr, nc, steps + 1});
                    visited.insert(to_string(nr) + "," + 
                                 to_string(nc));
                }
            }
        }
        
        // If we couldn't find the key, return -1
        if (!found) {
            return -1;
        }
    }
    
    return totalSteps;
}