def calculate_resilience(production):

    n = len(production)
    resilience = [1] * n
    
    # Calculate products of all elements to the left
    left_product = 1
    for i in range(n):
        resilience[i] = left_product
        left_product *= production[i]
    
    # Calculate products of all elements to the right
    # and multiply with existing values
    right_product = 1
    for i in range(n-1, -1, -1):
        resilience[i] *= right_product
        right_product *= production[i]
    
    return resilience