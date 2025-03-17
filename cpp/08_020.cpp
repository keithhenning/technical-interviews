#include <vector>
#include <queue>
#include <string>
#include <functional>
#include <limits>

struct Evidence {
    std::string id;
    int importance;
    int processingTime;
    int daysUntilExpiration;
    
    Evidence(std::string id, int importance, 
            int processingTime, int daysUntilExpiration)
        : id(id), importance(importance), 
          processingTime(processingTime), 
          daysUntilExpiration(daysUntilExpiration) {}
    
    double getPriority(int currentDay) const {
        int daysLeft = daysUntilExpiration - currentDay;
        if (daysLeft <= 0) 
            return -std::numeric_limits<double>::infinity();
        return (importance / (double)processingTime) * 
               (1.0 / daysLeft);
    }
};

class EvidenceComparator {
private:
    int currentDay;
    
public:
    EvidenceComparator(int day) : currentDay(day) {}
    
    bool operator()(const Evidence& e1, 
                   const Evidence& e2) const {
        return e1.getPriority(currentDay) < 
               e2.getPriority(currentDay);
    }
};

std::vector<std::string> processEvidence(
        std::vector<Evidence> evidence, int hoursPerDay) {
    std::vector<std::string> processingOrder;
    int currentDay = 0;
    int hoursLeftToday = hoursPerDay;
    
    // Max heap
    using EvidenceQueue = std::priority_queue
        Evidence, 
        std::vector<Evidence>, 
        EvidenceComparator>;
    
    EvidenceQueue evidenceQueue(
        EvidenceComparator(currentDay));
    
    for (const auto& item : evidence) {
        evidenceQueue.push(item);
    }
    
    while (!evidenceQueue.empty()) {
        Evidence item = evidenceQueue.top();
        evidenceQueue.pop();
        
        if (item.daysUntilExpiration <= currentDay) {
            continue;
        }
        
        processingOrder.push_back(item.id);
        
        int remainingTime = item.processingTime;
        while (remainingTime > 0) {
            if (hoursLeftToday >= remainingTime) {
                hoursLeftToday -= remainingTime;
                remainingTime = 0;
            } else {
                remainingTime -= hoursLeftToday;
                currentDay++;
                hoursLeftToday = hoursPerDay;
                
                // Reorder queue with updated priorities
                std::vector<Evidence> remaining;
                while (!evidenceQueue.empty()) {
                    remaining.push_back(evidenceQueue.top());
                    evidenceQueue.pop();
                }
                
                EvidenceQueue updatedQueue(
                    EvidenceComparator(currentDay));
                
                for (const auto& e : remaining) {
                    if (e.daysUntilExpiration > currentDay) {
                        updatedQueue.push(e);
                    }
                }
                
                evidenceQueue = std::move(updatedQueue);
            }
        }
    }
    
    return processingOrder;
}