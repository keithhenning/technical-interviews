#include <string>
using namespace std;

// Node structure for a baseball player
struct PlayerNode {
   string name;
   double battingAverage;
   PlayerNode* next;
   
   // Constructor with default next pointer as nullptr
   PlayerNode(const string& _name, double _average, 
         PlayerNode* _next = nullptr) 
      : name(_name), battingAverage(_average), 
        next(_next) {}
};

class Solution {
public:
   // Rotate lineup by k positions and find best batter
   string rotateLineupAndFindBest(PlayerNode* head, 
                                 int k, int m) {
      // Handle edge cases
      if (!head || head->next == head || k == 0) {
         return findBestBatter(head, m);
      }
      
      // Find the kth node
      PlayerNode* current = head;
      for (int i = 0; i < k - 1; i++) {
         current = current->next;
      }
      
      // The kth node will be our new head
      PlayerNode* newHead = current->next;
      
      // Find the last node (pointing to original head)
      PlayerNode* last = newHead;
      while (last->next != head) {
         last = last->next;
      }
      
      // Adjust pointers to rotate
      current->next = head;  // Connect kth node to head
      last->next = newHead;  // Update circular reference
      
      // Find the best batter in the window
      return findBestBatter(newHead, m);
   }
   
private:
   // Find player with highest batting average in window
   string findBestBatter(PlayerNode* head, int m) {
      if (!head) {
         return "";
      }
      
      PlayerNode* bestPlayer = head;
      PlayerNode* current = head;
      
      // Check the first m players
      for (int i = 0; i < m - 1; i++) {
         current = current->next;
         // Update best player if current has better average
         if (current->battingAverage > 
             bestPlayer->battingAverage) {
            bestPlayer = current;
         }
         
         // Handle circular list boundary
         if (current == head) {
            break;
         }
      }
      
      return bestPlayer->name;
   }
};