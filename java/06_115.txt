public static int coinChange(int[] coins, int amount, 
        Map<Integer, Integer> memo) {
    if (memo == null) {
        memo = new HashMap<>();
    }
    
    if (memo.containsKey(amount)) {
        return memo.get(amount);
    }
    
    if (amount == 0) {
        return 0;
    }
    
    if (amount < 0) {
        return Integer.MAX_VALUE;
    }
    
    int minCoins = Integer.MAX_VALUE;
    for (int coin : coins) {
        int result = coinChange(coins, amount - coin, memo);
        if (result != Integer.MAX_VALUE) {
            minCoins = Math.min(minCoins, result + 1);
        }
    }
    
    memo.put(amount, minCoins);
    return minCoins;
}