#include <vector>
#include <deque>

class SlidingWindowExtremaProduct {
public:
    std::vector<int> findExtremaProducts(
            std::vector<int>& prices, int k) {
        int n = prices.size();
        std::vector<int> result;
        
        if (n == 0 || k == 0 || k > n) {
            return result;
        }
        
        std::deque<int> maxDeque;
        std::deque<int> minDeque;
        
        // Process the first window
        for (int i = 0; i < k; i++) {
            // Remove smaller elements from maxDeque
            while (!maxDeque.empty() && 
                   prices[i] >= prices[maxDeque.back()]) {
                maxDeque.pop_back();
            }
            maxDeque.push_back(i);
            
            // Remove larger elements from minDeque
            while (!minDeque.empty() && 
                   prices[i] <= prices[minDeque.back()]) {
                minDeque.pop_back();
            }
            minDeque.push_back(i);
        }
        
        // Calculate product for the first window
        result.push_back(prices[maxDeque.front()] * 
                        prices[minDeque.front()]);
        
        // Process the rest of the windows
        for (int i = k; i < n; i++) {
            // Remove elements outside the current window
            while (!maxDeque.empty() && 
                   maxDeque.front() <= i - k) {
                maxDeque.pop_front();
            }
            while (!minDeque.empty() && 
                   minDeque.front() <= i - k) {
                minDeque.pop_front();
            }
            
            // Remove smaller elements from maxDeque
            while (!maxDeque.empty() && 
                   prices[i] >= prices[maxDeque.back()]) {
                maxDeque.pop_back();
            }
            maxDeque.push_back(i);
            
            // Remove larger elements from minDeque
            while (!minDeque.empty() && 
                   prices[i] <= prices[minDeque.back()]) {
                minDeque.pop_back();
            }
            minDeque.push_back(i);
            
            // Calculate product for the current window
            result.push_back(prices[maxDeque.front()] * 
                            prices[minDeque.front()]);
        }
        
        return result;
    }
};