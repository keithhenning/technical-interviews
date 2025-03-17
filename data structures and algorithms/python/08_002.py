def find_price_pair(prices, budget):
  price_map = {}
  
  for i, price in enumerate(prices):
     complement = budget - price
     
     if complement in price_map:
        return [price_map[complement], i]
     
     price_map[price] = i
  
  return []