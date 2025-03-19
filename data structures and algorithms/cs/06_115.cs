using System.Collections.Generic;

public static int CoinChange(int[] coins, int amount, Dictionary<int, int> memo = null) {
    if (memo == null) {
        memo = new Dictionary<int, int>();
    }
    
    if (memo.ContainsKey(amount)) {
        return memo[amount];
    }
    
    if (amount == 0) {
        return 0;
    }
    
    if (amount < 0) {
        return int.MaxValue;
    }
    
    int minCoins = int.MaxValue;
    foreach (int coin in coins) {
        int result = CoinChange(coins, amount - coin, memo);
        if (result != int.MaxValue) {
            minCoins = Math.Min(minCoins, result + 1);
        }
    }
    
    memo[amount] = minCoins;
    return minCoins;
}