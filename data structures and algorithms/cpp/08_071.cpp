#include <stack>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

// Structure to represent a clothing item
struct ClothingItem {
   string type;
   int popularity;
   
   // Constructor for clothing item
   ClothingItem(string t, int p) : type(t), popularity(p) {}
};

// Class to manage a stack of clothing items
class FashionStack {
private:
   stack<ClothingItem> mainStack;
   stack<ClothingItem> tempStack;
   
public:
   // Add a new clothing item to the stack
   void addItem(string type, int popularity) {
      mainStack.push(ClothingItem(type, popularity));
   }
   
   // Remove and return the top item from the stack
   ClothingItem removeTopItem() {
      if (mainStack.empty()) {
         return ClothingItem("", -1); // Invalid item
      }
      
      ClothingItem top = mainStack.top();
      mainStack.pop();
      return top;
   }
   
   // Find and remove most popular item of target type
   ClothingItem findAndRemoveType(string targetType) {
      if (mainStack.empty()) {
         return ClothingItem("", -1); // Invalid item
      }
      
      // Convert stack to vector for easier searching
      vector<ClothingItem> items;
      while (!mainStack.empty()) {
         items.push_back(mainStack.top());
         mainStack.pop();
      }
      
      // Find most popular item of target type
      ClothingItem* mostPopular = nullptr;
      int mostPopularIndex = -1;
      
      for (int i = 0; i < items.size(); i++) {
         if (items[i].type == targetType) {
            if (mostPopular == nullptr || 
                items[i].popularity > mostPopular->popularity) {
               mostPopular = &items[i];
               mostPopularIndex = i;
            }
         }
      }
      
      if (mostPopularIndex == -1) {
         // Restore stack and return invalid item
         for (int i = items.size() - 1; i >= 0; i--) {
            mainStack.push(items[i]);
         }
         return ClothingItem("", -1);
      }
      
      // Save the result
      ClothingItem result = items[mostPopularIndex];
      
      // Rebuild stack without the found item
      for (int i = items.size() - 1; i >= 0; i--) {
         if (i != mostPopularIndex) {
            mainStack.push(items[i]);
         }
      }
      
      return result;
   }
   
   // Reorganize stack by popularity (highest first)
   void reorganizeByPopularity() {
      if (mainStack.empty()) {
         return;
      }
      
      // Convert stack to vector
      vector<ClothingItem> items;
      while (!mainStack.empty()) {
         items.push_back(mainStack.top());
         mainStack.pop();
      }
      
      // Sort by popularity (highest first)
      sort(items.begin(), items.end(), 
           [](const ClothingItem& a, const ClothingItem& b) {
         return a.popularity > b.popularity;
      });
      
      // Rebuild stack with sorted items
      for (const auto& item : items) {
         mainStack.push(item);
      }
   }
};