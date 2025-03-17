def max_property_profit(prices):

    if not prices or len(prices) < 2:
        return 0
    
    min_price = float('inf')
    max_profit = 0
    
    for price in prices:
        if price < min_price:
            min_price = price
        else:
            current_profit = price - min_price
            max_profit = max(max_profit, current_profit)
    
    return max_profit