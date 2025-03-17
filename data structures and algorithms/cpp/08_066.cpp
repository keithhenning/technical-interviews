#include <vector>
#include <algorithm>
#include <random>
using namespace std;

class Solution {
public:
   // Maximize wedding happiness with table assignments
   int maxWeddingHappiness(vector<vector<int>>& relationships,
         int tables, int seatsPerTable) {
      int n = relationships.size();
      // Check if we have enough seats
      if (n > tables * seatsPerTable) {
         return -1;  // Not enough seats for all guests
      }
      
      // Initialize with random seating
      vector<int> guests(n);
      for (int i = 0; i < n; i++) {
         guests[i] = i;
      }
      random_device rd;
      mt19937 g(rd());
      shuffle(guests.begin(), guests.end(), g);
      
      // Distribute guests among tables
      vector<vector<int>> seating(tables);
      for (int t = 0; t < tables; t++) {
         int startIdx = t * seatsPerTable;
         int endIdx = min(startIdx + seatsPerTable, n);
         
         if (startIdx < n) {
            for (int i = startIdx; i < endIdx; i++) {
               seating[t].push_back(guests[i]);
            }
         }
      }
      
      // Local search optimization
      bool improved = true;
      while (improved) {
         improved = false;
         int bestSwapGain = 0;
         vector<int> bestSwap;
         
         // Try all possible guest swaps between tables
         for (int t1 = 0; t1 < tables; t1++) {
            for (int t2 = 0; t2 < tables; t2++) {
               if (t1 == t2) {
                  continue;
               }
               
               for (int i = 0; i < seating[t1].size(); i++) {
                  for (int j = 0; j < seating[t2].size(); j++) {
                     // Skip if table 1 is already full
                     if (seating[t2].size() >= seatsPerTable) {
                        continue;
                     }
                     
                     int guest1 = seating[t1][i];
                     int guest2 = seating[t2][j];
                     
                     // Calculate score before swap
                     int oldScore = tableScore(seating[t1], 
                                          relationships) + 
                                 tableScore(seating[t2], 
                                          relationships);
                     
                     // Perform swap
                     vector<int> newT1 = seating[t1];
                     vector<int> newT2 = seating[t2];
                     newT1.erase(newT1.begin() + i);
                     newT2.erase(newT2.begin() + j);
                     newT1.push_back(guest2);
                     newT2.push_back(guest1);
                     
                     // Calculate score after swap
                     int newScore = tableScore(newT1, 
                                          relationships) + 
                                 tableScore(newT2, 
                                          relationships);
                     int gain = newScore - oldScore;
                     
                     if (gain > bestSwapGain) {
                        bestSwapGain = gain;
                        bestSwap = {t1, i, t2, j};
                     }
                  }
               }
            }
         }
         
         // Apply the best swap if it improves the score
         if (bestSwapGain > 0) {
            int t1 = bestSwap[0], i = bestSwap[1];
            int t2 = bestSwap[2], j = bestSwap[3];
            int guest1 = seating[t1][i];
            int guest2 = seating[t2][j];
            seating[t1].erase(seating[t1].begin() + i);
            seating[t2].erase(seating[t2].begin() + j);
            seating[t1].push_back(guest2);
            seating[t2].push_back(guest1);
            improved = true;
         }
      }
      
      return totalScore(seating, relationships);
   }
   
private:
   // Calculate happiness score for a single table
   int tableScore(const vector<int>& tableGuests, 
               const vector<vector<int>>& relationships) {
      int score = 0;
      for (int i = 0; i < tableGuests.size(); i++) {
         for (int j = i + 1; j < tableGuests.size(); j++) {
            score += relationships[tableGuests[i]]
                              [tableGuests[j]];
         }
      }
      return score;
   }
   
   // Calculate total happiness score across all tables
   int totalScore(const vector<vector<int>>& seating, 
               const vector<vector<int>>& relationships) {
      int score = 0;
      for (const auto& table : seating) {
         score += tableScore(table, relationships);
      }
      return score;
   }
};