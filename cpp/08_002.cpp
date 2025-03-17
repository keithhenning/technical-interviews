#include <vector>
#include <unordered_map>

std::vector<int> findPricePair(std::vector<int>& prices, 
                              int budget) {
    std::unordered_map<int, int> priceMap;
    
    for (int i = 0; i < prices.size(); i++) {
        int complement = budget - prices[i];
        
        if (priceMap.find(complement) != priceMap.end()) {
            return {priceMap[complement], i};
        }
        
        priceMap[prices[i]] = i;
    }
    
    return {};  // No solution found
}