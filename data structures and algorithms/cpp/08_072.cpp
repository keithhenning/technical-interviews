#include <iostream>
#include <vector>
#include <queue>
#include <string>
#include <algorithm>

using namespace std;

// Structure to represent a restaurant customer
struct Customer {
   string id;
   int partySize;
   int vipStars;
   bool hasReservation;
   int arrivalTime;
   
   // Constructor
   Customer(string id, int partySize, int vipStars, 
         bool hasReservation, int arrivalTime)
      : id(id), partySize(partySize), vipStars(vipStars), 
        hasReservation(hasReservation), 
        arrivalTime(arrivalTime) {}
   
   // Calculate customer priority based on various factors
   int getPriority(int currentTime) const {
      int waitingTime = currentTime - arrivalTime;
      return (vipStars * 10) + 
             (hasReservation ? 20 : 0) + 
             waitingTime;
   }
};

// Structure to represent seating result
struct Result {
   string customerId;
   int seatedTime;
   
   // Constructor
   Result(string customerId, int seatedTime)
      : customerId(customerId), seatedTime(seatedTime) {}
};

// Custom comparator for the priority queue
class CustomerComparator {
private:
   int currentTime;
   
public:
   CustomerComparator(int time) : currentTime(time) {}
   
   // Compare customers by priority
   bool operator()(const Customer& c1, 
                  const Customer& c2) const {
      // In C++ priority_queue, use "less" for max-heap
      return c1.getPriority(currentTime) < 
             c2.getPriority(currentTime);
   }
};

// Process restaurant events and seat customers
vector<Result> restaurantPrioritySeating(
   const vector<int>& tables, 
   const vector<vector<variant<string, int, bool>>>& events) {
   
   // Sort events by time
   vector<vector<variant<string, int, bool>>> sortedEvents = 
      events;
   sort(sortedEvents.begin(), sortedEvents.end(), 
        [](const auto& e1, const auto& e2) { 
           return get<int>(e1[1]) < get<int>(e2[1]); 
        });
   
   vector<Result> results;
   int currentTime = 0;
   priority_queue<Customer, vector<Customer>, 
                 CustomerComparator> waitlist(
                    CustomerComparator(currentTime));
   
   for (const auto& event : sortedEvents) {
      string eventType = get<string>(event[0]);
      currentTime = get<int>(event[1]);
      
      // Update priority queue with new time
      vector<Customer> tempCustomers;
      while (!waitlist.empty()) {
         tempCustomers.push_back(waitlist.top());
         waitlist.pop();
      }
      
      priority_queue<Customer, vector<Customer>, 
                    CustomerComparator> updatedWaitlist(
                       CustomerComparator(currentTime));
      for (const auto& customer : tempCustomers) {
         updatedWaitlist.push(customer);
      }
      waitlist = move(updatedWaitlist);
      
      if (eventType == "ARRIVE") {
         string customerId = get<string>(event[2]);
         int partySize = get<int>(event[3]);
         int vipStars = get<int>(event[4]);
         bool hasReservation = get<bool>(event[5]);
         
         Customer newCustomer(customerId, partySize, 
                            vipStars, hasReservation, 
                            currentTime);
         waitlist.push(newCustomer);
      } 
      else if (eventType == "TABLE_READY") {
         int tableSize = get<int>(event[2]);
         
         vector<Customer> temp;
         bool seated = false;
         
         while (!waitlist.empty() && !seated) {
            Customer customer = waitlist.top();
            waitlist.pop();
            
            if (customer.partySize <= tableSize) {
               results.push_back(
                  Result(customer.id, currentTime));
               seated = true;
            } else {
               temp.push_back(customer);
            }
         }
         
         // Restore customers we examined but didn't seat
         for (const auto& customer : temp) {
            waitlist.push(customer);
         }
      }
   }
   
   return results;
}