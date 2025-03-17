#include <vector>
#include <set>
#include <unordered_map>
#include <queue>
#include <iostream>
#include <algorithm>

// Structure to represent a 2D point
struct Point {
   int x, y;
   
   // Constructor with default values
   Point(int x = 0, int y = 0) : x(x), y(y) {}
   
   // Equality operator for point comparison
   bool operator==(const Point& other) const {
      return x == other.x && y == other.y;
   }
   
   // Less than operator for set ordering
   bool operator<(const Point& other) const {
      return x < other.x || (x == other.x && y < other.y);
   }
};

// Hash function for Point in std namespace
namespace std {
   template <>
   struct hash<Point> {
      size_t operator()(const Point& p) const {
         return hash<int>()(p.x) ^ (hash<int>()(p.y) << 1);
      }
   };
}

// A* Pathfinding Algorithm Implementation
class AStar {
private:
   // Manhattan distance heuristic
   static int heuristic(const Point& a, const Point& b) {
      return std::abs(a.x - b.x) + std::abs(a.y - b.y);
   }
   
   // Get valid neighboring cells
   static std::vector<Point> getNeighbors(
         const Point& pos,
         const std::vector<std::vector<int>>& grid) {
      std::vector<Point> neighbors;
      const int dx[] = {1, -1, 0, 0};
      const int dy[] = {0, 0, 1, -1};
      
      for (int i = 0; i < 4; i++) {
         int newX = pos.x + dx[i];
         int newY = pos.y + dy[i];
         
         // Check boundaries and obstacles
         if (newX >= 0 && newX < grid.size() && 
             newY >= 0 && newY < grid[0].size() && 
             grid[newX][newY] != 1) {
            neighbors.emplace_back(newX, newY);
         }
      }
      return neighbors;
   }

public:
   // Find path from start to goal
   static std::vector<Point> findPath(
         const std::vector<std::vector<int>>& grid, 
         const Point& start, const Point& goal) {
      std::set<Point> openSet;
      std::set<Point> closedSet;
      std::unordered_map<Point, Point> cameFrom;
      std::unordered_map<Point, int> gScore;
      std::unordered_map<Point, int> fScore;
      
      // Initialize with start point
      openSet.insert(start);
      gScore[start] = 0;
      fScore[start] = heuristic(start, goal);
      
      while (!openSet.empty()) {
         // Find point with lowest fScore
         Point current = *std::min_element(
               openSet.begin(), openSet.end(),
               [&fScore](const Point& a, const Point& b) {
                  return fScore[a] < fScore[b];
               });
         
         // Check if reached goal
         if (current == goal) {
            // Reconstruct path
            std::vector<Point> path;
            while (cameFrom.find(current) != 
                  cameFrom.end()) {
               path.push_back(current);
               current = cameFrom[current];
            }
            path.push_back(start);
            std::reverse(path.begin(), path.end());
            return path;
         }
         
         // Move from open to closed set
         openSet.erase(current);
         closedSet.insert(current);
         
         // Check all neighbors
         for (const Point& neighbor : 
               getNeighbors(current, grid)) {
            // Skip if already evaluated
            if (closedSet.find(neighbor) != 
                closedSet.end())
               continue;
            
            // Calculate tentative gScore
            int tentativeGScore = gScore[current] + 1;
            
            // Add to open set if not there
            if (openSet.find(neighbor) == openSet.end()) {
               openSet.insert(neighbor);
            } else if (tentativeGScore >= 
                      gScore[neighbor]) {
               continue;
            }
            
            // This path is better, record it
            cameFrom[neighbor] = current;
            gScore[neighbor] = tentativeGScore;
            fScore[neighbor] = gScore[neighbor] + 
                              heuristic(neighbor, goal);
         }
      }
      
      return std::vector<Point>();  // No path found
   }
   
   // Print grid with path visualization
   static void printPath(
         const std::vector<std::vector<int>>& grid,
         const std::vector<Point>& path) {
      for (size_t i = 0; i < grid.size(); i++) {
         for (size_t j = 0; j < grid[0].size(); j++) {
            Point current(i, j);
            auto it = std::find(path.begin(), path.end(), 
                              current);
            if (current == path.front()) {
               std::cout << "S ";
            } else if (current == path.back()) {
               std::cout << "G ";
            } else if (it != path.end()) {
               std::cout << "* ";
            } else if (grid[i][j] == 1) {
               std::cout << "&#x2588; ";
            } else {
               std::cout << ". ";
            }
         }
         std::cout << std::endl;
      }
   }
};

int main() {
   // Define grid with obstacles (1's)
   std::vector<std::vector<int>> grid = {
      {0, 0, 0, 0, 0},
      {1, 1, 0, 1, 0},
      {0, 0, 0, 0, 0},
      {0, 1, 1, 0, 0},
      {0, 0, 0, 0, 0}
   };
   
   // Define start and goal points
   Point start(0, 0);
   Point goal(4, 4);
   
   // Find and print path
   auto path = AStar::findPath(grid, start, goal);
   std::cout << "Found path: ";
   for (const auto& p : path) {
      std::cout << "(" << p.x << "," << p.y << ") ";
   }
   std::cout << "\n\nGrid visualization:\n";
   AStar::printPath(grid, path);
   
   return 0;
}