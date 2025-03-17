def coin_change(coins, amount, memo={}):
    if amount in memo:
        return memo[amount]
    if amount == 0:
        return 0
    if amount < 0:
        return float('inf')
        
    min_coins = float('inf')
    for coin in coins:
        result = coin_change(coins, amount - coin, memo) + 1
        min_coins = min(min_coins, result)
        
    memo[amount] = min_coins
    return min_coins