#include <vector>
#include <climits>
#include <algorithm>

int maxPropertyProfit(std::vector<int>& prices) {
    if (prices.size() < 2) {
        return 0;
    }
    
    int minPrice = INT_MAX;
    int maxProfit = 0;
    
    for (int price : prices) {
        if (price < minPrice) {
            minPrice = price;
        } else {
            int currentProfit = price - minPrice;
            maxProfit = std::max(maxProfit, currentProfit);
        }
    }
    
    return maxProfit;
}