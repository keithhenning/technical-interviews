#include <iostream>
#include <vector>
#include <unordered_set>
#include <algorithm>

using namespace std;

class OptimalRaceDayStrategy {
private:
   // Performance ratings for each horse in each race
   vector<vector<int>> performanceRatings;
   // Maximum number of horses allowed in each race
   vector<int> raceCapacity;
   
   // Using custom hash function for pair
   struct PairHash {
      template <class T1, class T2>
      size_t operator() (const pair<T1, T2>& p) const {
         auto h1 = hash<T1>{}(p.first);
         auto h2 = hash<T2>{}(p.second);
         return h1 ^ h2;
      }
   };
   
   // Set of horse-race pairs that are ineligible
   unordered_set<pair<int, int>, PairHash> ineligible;
   // Tracks the best assignment found
   vector<int> bestAssignment;
   int bestPoints;
   int nHorses;
   int nRaces;
   
   // Recursive backtracking to find optimal assignment
   void backtrack(int horseIdx, vector<int>& assignments, 
                vector<int>& raceCounts, int totalPoints) {
      // Base case: all horses assigned
      if (horseIdx == nHorses) {
         // Check if all races have at least one horse
         bool allRacesHaveHorses = true;
         for (int count : raceCounts) {
            if (count == 0) {
               allRacesHaveHorses = false;
               break;
            }
         }
         
         if (allRacesHaveHorses && totalPoints > bestPoints) {
            bestPoints = totalPoints;
            bestAssignment = assignments;
         }
         return;
      }
      
      // Try each possible race for this horse
      for (int race = 0; race < nRaces; race++) {
         // Skip if horse ineligible or race is full
         if (ineligible.find({horseIdx, race}) != 
             ineligible.end() || 
             raceCounts[race] >= raceCapacity[race]) {
            continue;
         }
         
         // Make assignment
         assignments[horseIdx] = race;
         raceCounts[race]++;
         
         // Recurse to next horse
         backtrack(horseIdx + 1, assignments, raceCounts, 
                  totalPoints + 
                  performanceRatings[horseIdx][race]);
         
         // Undo assignment (backtrack)
         raceCounts[race]--;
         assignments[horseIdx] = -1;
      }
   }

public:
   // Constructor
   OptimalRaceDayStrategy(const vector<vector<int>>& ratings, 
                        const vector<int>& capacity,
                        const vector<pair<int, int>>& 
                           ineligiblePairs) {
      performanceRatings = ratings;
      raceCapacity = capacity;
      
      for (const auto& pair : ineligiblePairs) {
         ineligible.insert(pair);
      }
      
      nHorses = ratings.size();
      nRaces = capacity.size();
      bestPoints = 0;
      bestAssignment.resize(nHorses, -1);
   }
   
   // Find the optimal assignment of horses to races
   vector<int> optimizeRaces() {
      vector<int> currentAssignment(nHorses, -1);
      vector<int> raceCounts(nRaces, 0);
      
      backtrack(0, currentAssignment, raceCounts, 0);
      
      return bestPoints > 0 ? bestAssignment : vector<int>();
   }
   
   // Return the total points for the best assignment
   int getBestPoints() const {
      return bestPoints;
   }
};

int main() {
   // Sample performance ratings for horses
   vector<vector<int>> ratings = {
      {80, 40, 60},
      {20, 90, 30},
      {45, 50, 70},
      {60, 45, 30},
      {50, 55, 55}
   };
   
   // Capacity of each race
   vector<int> capacity = {2, 2, 2};
   
   // Ineligible horse-race pairs
   vector<pair<int, int>> ineligibility = {
      {0, 1},
      {3, 2}
   };
   
   // Create and run the optimizer
   OptimalRaceDayStrategy strategy(ratings, capacity, 
                                 ineligibility);
   vector<int> assignments = strategy.optimizeRaces();
   
   // Output results
   cout << "Maximum points: " << strategy.getBestPoints() 
        << endl;
   cout << "Assignments: ";
   for (int i = 0; i < assignments.size(); i++) {
      cout << "Horse " << i << " → Race " 
           << assignments[i] << ", ";
   }
   
   return 0;
}