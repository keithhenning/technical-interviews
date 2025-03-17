from collections import deque

def sliding_window_extrema_product(prices, k):
    n = len(prices)
    result = []
    
    if n == 0 or k == 0 or k > n:
        return result
    
    max_deque = deque()
    min_deque = deque()
    
    # Process the first window
    for i in range(k):
        # Remove smaller elements from max_deque
        while max_deque and prices[i] >= prices[max_deque[-1]]:
            max_deque.pop()
        max_deque.append(i)
        
        # Remove larger elements from min_deque
        while min_deque and prices[i] <= prices[min_deque[-1]]:
            min_deque.pop()
        min_deque.append(i)
    
    # Calculate product for the first window
    result.append(prices[max_deque[0]] * prices[min_deque[0]])
    
    # Process the rest of the windows
    for i in range(k, n):
        # Remove elements outside the current window
        while max_deque and max_deque[0] <= i - k:
            max_deque.popleft()
        while min_deque and min_deque[0] <= i - k:
            min_deque.popleft()
        
        # Remove smaller elements from max_deque
        while max_deque and prices[i] >= prices[max_deque[-1]]:
            max_deque.pop()
        max_deque.append(i)
        
        # Remove larger elements from min_deque
        while min_deque and prices[i] <= prices[min_deque[-1]]:
            min_deque.pop()
        min_deque.append(i)
        
        # Calculate product for the current window
        result.append(prices[max_deque[0]] * 
                     prices[min_deque[0]])
    
    return result