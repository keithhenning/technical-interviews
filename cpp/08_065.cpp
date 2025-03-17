#include <vector>
#include <cmath>
#include <algorithm>
using namespace std;

class Solution {
public:
   // Calculate maximum kennel compatibility score
   int maxKennelCompatibility(
         vector<vector<int>>& compatibility) {
      int n = compatibility.size();
      int gridSize = sqrt(n);
      
      // Check if dogs can form a perfect square grid
      if (gridSize * gridSize != n) {
         return -1;  // Can't form a perfect square grid
      }
      
      // Initialize assignment grid and used dogs tracker
      vector<vector<int>> assignment(gridSize, 
                                 vector<int>(gridSize, -1));
      vector<bool> used(n, false);
      
      // Start backtracking from top-left corner
      return backtrack(compatibility, assignment, 0, 0, used, 
                     0, 0, gridSize);
   }
   
private:
   // Define four adjacent directions
   vector<pair<int, int>> directions = {{0, 1}, {1, 0}, 
                                     {0, -1}, {-1, 0}};
   
   // Backtracking function to try all possible placements
   int backtrack(vector<vector<int>>& compatibility, 
               vector<vector<int>>& assignment,
               int row, int col, vector<bool>& used, 
               int currentScore, int bestScore, int gridSize) {
      // If we've filled the entire grid, return the score
      if (row == gridSize) {
         return max(currentScore, bestScore);
      }
      
      // Calculate next position
      int nextRow = row, nextCol = col + 1;
      if (nextCol == gridSize) {
         nextRow = row + 1;
         nextCol = 0;
      }
      
      // Try placing each dog at the current position
      for (int dog = 0; dog < used.size(); dog++) {
         if (!used[dog]) {
            // Mark dog as used and assign to position
            used[dog] = true;
            assignment[row][col] = dog;
            
            // Calculate additional compatibility score
            int additionalScore = 0;
            for (auto& dir : directions) {
               int adjRow = row + dir.first;
               int adjCol = col + dir.second;
               
               // Check adjacent positions
               if (isValid(adjRow, adjCol, gridSize) && 
                  assignment[adjRow][adjCol] != -1) {
                  additionalScore += 
                     compatibility[dog][assignment[adjRow][adjCol]];
               }
            }
            
            // Recursive call with updated score
            bestScore = backtrack(compatibility, assignment, 
                              nextRow, nextCol, used, 
                              currentScore + additionalScore, 
                              bestScore, gridSize);
            
            // Backtrack
            assignment[row][col] = -1;
            used[dog] = false;
         }
      }
      
      return bestScore;
   }
   
   // Check if position is within grid boundaries
   bool isValid(int row, int col, int gridSize) {
      return row >= 0 && row < gridSize && 
            col >= 0 && col < gridSize;
   }
};