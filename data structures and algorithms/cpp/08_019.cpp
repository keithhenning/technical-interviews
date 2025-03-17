#include <unordered_map>
#include <deque>
#include <string>

class RateLimiter {
private:
    int messageLimit;
    int timeWindow;
    std::unordered_map<std::string, std::deque<int>> 
        userMessages;
    
public:
    RateLimiter(int messageLimit, int timeWindow) 
        : messageLimit(messageLimit), 
          timeWindow(timeWindow) {}
    
    bool canSend(const std::string& userId, int timestamp) {
        // Get or create the message queue for this user
        auto& messageQueue = userMessages[userId];
        
        // Remove messages outside the current time window
        while (!messageQueue.empty() && 
               messageQueue.front() <= 
                   timestamp - timeWindow) {
            messageQueue.pop_front();
        }
        
        // Check if adding a new message would exceed limit
        if (messageQueue.size() < 
            static_cast<size_t>(messageLimit)) {
            messageQueue.push_back(timestamp);
            return true;
        }
        
        return false;
    }
};