#include <list>

std::list<int> myList;
myList.push_back(1);    // Add to end
myList.push_front(0);   // Add to beginning
myList.pop_back();      // Remove from end
myList.insert(++myList.begin(), 2);  // Insert at position