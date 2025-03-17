#include <iostream>

// Node structure for boat in the fleet
struct BoatNode {
   int id;
   bool maintenanceNeeded;
   BoatNode* next;
   
   // Constructor with default next pointer as nullptr
   BoatNode(int _id, bool _maintenance, 
         BoatNode* _next = nullptr) 
      : id(_id), maintenanceNeeded(_maintenance), 
        next(_next) {}
};

class Solution {
public:
   // Reorder fleet to prioritize maintenance boats
   BoatNode* reorderFleet(BoatNode* head) {
      // Check for empty or single-node list
      if (!head || !head->next) {
         return head;
      }
      
      // Create dummy heads for our two chains
      BoatNode maintenanceDummy(0, false);
      BoatNode noMaintenanceDummy(0, false);
      
      // Pointers to track the end of each chain
      BoatNode* maintenanceTail = &maintenanceDummy;
      BoatNode* noMaintenanceTail = &noMaintenanceDummy;
      
      // Traverse the original list
      BoatNode* current = head;
      while (current) {
         // Save next boat before detaching
         BoatNode* nextBoat = current->next;
         current->next = nullptr;  // Detach the node
         
         // Add to appropriate chain based on maintenance
         if (current->maintenanceNeeded) {
            maintenanceTail->next = current;
            maintenanceTail = current;
         } else {
            noMaintenanceTail->next = current;
            noMaintenanceTail = current;
         }
         
         current = nextBoat;
      }
      
      // Connect maintenance boats to non-maintenance boats
      maintenanceTail->next = noMaintenanceDummy.next;
      
      // Return the head of the merged chain
      return maintenanceDummy.next;
   }
};