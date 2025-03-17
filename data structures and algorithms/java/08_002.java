import java.util.HashMap;
import java.util.Map;

public int[] findPricePair(int[] prices, int budget) {
    Map<Integer, Integer> priceMap = new HashMap<>();
    
    for (int i = 0; i < prices.length; i++) {
        int complement = budget - prices[i];
        
        if (priceMap.containsKey(complement)) {
            return new int[] {priceMap.get(complement), i};
        }
        
        priceMap.put(prices[i], i);
    }
    
    return new int[] {};  // No solution found
}