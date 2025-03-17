#include <iostream>
#include <vector>
#include <map>
#include <unordered_map>
#include <unordered_set>
#include <set>
#include <algorithm>
#include <string>
#include <queue>

using namespace std;

// Case structure with id, type and complexity
struct Case {
   int id;
   string type;
   int complexity;
   
   // Constructor
   Case(int id, string type, int complexity)
      : id(id), type(type), complexity(complexity) {}
};

// Assignment structure with time, case and detectives
struct Assignment {
   double time;
   int caseId;
   vector<int> detectiveIds;
   
   // Constructor
   Assignment(double time, int caseId, 
         vector<int> detectiveIds)
      : time(time), caseId(caseId), 
        detectiveIds(detectiveIds) {}
   
   // Comparison operator for sorting
   bool operator<(const Assignment& other) const {
      return time < other.time;
   }
};

// Hash function for vector<int> to use in unordered_map
struct VectorHash {
   size_t operator()(const vector<int>& v) const {
      size_t hash = 0;
      for (int i : v) {
         hash ^= i + 0x9e3779b9 + (hash << 6) + 
                (hash >> 2);
      }
      return hash;
   }
};

// Main function to solve detective cases
double solveCases(int numDetectives, vector<Case>& cases, 
      unordered_map<int, unordered_map<string, int>>& 
         expertise,
      unordered_map<vector<int>, int, VectorHash>& 
         communicationOverhead) {
   
   vector<Assignment> possibleAssignments;
   
   // Create individual detective assignments
   for (const Case& c : cases) {
      for (int detective = 0; detective < numDetectives; 
           detective++) {
         auto& detectiveExpertise = expertise[detective];
         if (detectiveExpertise.find(c.type) != 
             detectiveExpertise.end()) {
            double time = static_cast<double>(c.complexity) / 
                         detectiveExpertise[c.type];
            possibleAssignments.push_back(
               Assignment(time, c.id, {detective}));
         }
      }
   }
   
   // Create collaborative assignments
   for (const auto& entry : communicationOverhead) {
      const vector<int>& pair = entry.first;
      int overhead = entry.second;
      int det1 = pair[0];
      int det2 = pair[1];
      
      for (const Case& c : cases) {
         // Check if both detectives have expertise
         if (expertise[det1].find(c.type) != 
             expertise[det1].end() && 
             expertise[det2].find(c.type) != 
             expertise[det2].end()) {
            
            int combinedExpertise = expertise[det1][c.type] + 
                                   expertise[det2][c.type];
            double time = static_cast<double>(c.complexity) / 
                         combinedExpertise + overhead;
            possibleAssignments.push_back(
               Assignment(time, c.id, {det1, det2}));
         }
      }
   }
   
   // Sort assignments by time
   sort(possibleAssignments.begin(), 
        possibleAssignments.end());
   
   unordered_set<int> assignedCases;
   unordered_set<int> busyDetectives;
   double parallelTime = 0;
   double sequentialTime = 0;
   
   // Assign cases until all are solved
   while (assignedCases.size() < cases.size()) {
      bool madeAssignment = false;
      
      for (const Assignment& assignment : 
           possibleAssignments) {
         // Skip already assigned cases
         if (assignedCases.find(assignment.caseId) != 
             assignedCases.end()) {
            continue;
         }
         
         // Check if all detectives are available
         bool detectivesAvailable = true;
         for (int detective : assignment.detectiveIds) {
            if (busyDetectives.find(detective) != 
                busyDetectives.end()) {
               detectivesAvailable = false;
               break;
            }
         }
         
         // Make assignment if possible
         if (detectivesAvailable) {
            assignedCases.insert(assignment.caseId);
            for (int detective : assignment.detectiveIds) {
               busyDetectives.insert(detective);
            }
            
            // Update time tracking
            if (parallelTime < assignment.time) {
               sequentialTime += assignment.time - 
                               parallelTime;
               parallelTime = assignment.time;
            }
            
            madeAssignment = true;
            break;
         }
      }
      
      // If no assignment was made, reset for next round
      if (!madeAssignment) {
         sequentialTime += parallelTime;
         parallelTime = 0;
         busyDetectives.clear();
      }
   }
   
   return sequentialTime + parallelTime;
}