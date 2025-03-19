using System.Collections.Generic;

public int[] FindPricePair(int[] prices, int budget) {
    Dictionary<int, int> priceMap = new Dictionary<int, int>();
    
    for (int i = 0; i < prices.Length; i++) {
        int complement = budget - prices[i];
        
        if (priceMap.ContainsKey(complement)) {
            return new int[] {priceMap[complement], i};
        }
        
        priceMap[prices[i]] = i;
    }
    
    return new int[] {};  // No solution found
}