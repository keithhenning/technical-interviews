public int maxPropertyProfit(int[] prices) {
    if (prices == null || prices.length < 2) {
        return 0;
    }
    
    int minPrice = Integer.MAX_VALUE;
    int maxProfit = 0;
    
    for (int price : prices) {
        if (price < minPrice) {
            minPrice = price;
        } else {
            int currentProfit = price - minPrice;
            maxProfit = Math.max(maxProfit, currentProfit);
        }
    }
    
    return maxProfit;
}