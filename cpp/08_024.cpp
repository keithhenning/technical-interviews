#include <iostream>
#include <vector>
#include <queue>

struct Position {
    int x, y, time;
    Position(int x, int y, int time): 
        x(x), y(y), time(time) {}
};

int floodFillTime(std::vector<std::vector<int>>& maze, 
                 int startX, int startY, 
                 int targetX, int targetY) {
    int rows = maze.size();
    int cols = maze[0].size();
    
    std::vector<std::vector<bool>> visited(
        rows, std::vector<bool>(cols, false));
    
    std::queue<Position> q;
    q.push(Position(startX, startY, 0));
    visited[startX][startY] = true;
    
    std::vector<std::pair<int, int>> directions = 
        {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};
    
    while (!q.empty()) {
        Position current = q.front();
        q.pop();
        
        if (current.x == targetX && current.y == targetY) {
            return current.time;
        }
        
        for (auto& dir : directions) {
            int nx = current.x + dir.first;
            int ny = current.y + dir.second;
            
            if (nx >= 0 && nx < rows && 
                ny >= 0 && ny < cols && 
                !visited[nx][ny] && maze[nx][ny] == 0) {
                visited[nx][ny] = true;
                q.push(Position(nx, ny, current.time + 1));
            }
        }
    }
    
    return -1;  // Target not reachable
}

int main() {
    std::vector<std::vector<int>> maze = {
        {0, 0, 0, 0},
        {1, 1, 0, 1},
        {0, 2, 0, 0},
        {0, 1, 1, 0}
    };
    
    std::cout << floodFillTime(maze, 2, 1, 0, 0) 
              << std::endl;  // Output: 3
    
    return 0;
}