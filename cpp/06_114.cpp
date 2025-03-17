int coinChange(const std::vector<int>& coins, int amount,
               std::unordered_map<int, int>& memo) {
    if (memo.find(amount) != memo.end()) {
        return memo[amount];
    }
    if (amount == 0) {
        return 0;
    }
    if (amount < 0) {
        return INT_MAX;
    }
    
    int minCoins = INT_MAX;
    for (int coin : coins) {
        int result = coinChange(coins, amount - coin, memo);
        if (result != INT_MAX) {
            minCoins = std::min(minCoins, result + 1);
        }
    }
    
    memo[amount] = minCoins;
    return minCoins;
}