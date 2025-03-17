def max_artwork_value(values):

    n = len(values)
    if n == 0:
        return 0
    if n == 1:
        return values[0]
        
    # Initialize previous two values
    prev2 = values[0]
    prev1 = max(values[0], values[1])
    
    # Compute max value
    for i in range(2, n):
        current = max(prev1, prev2 + values[i])
        prev2 = prev1
        prev1 = current
    
    return prev1