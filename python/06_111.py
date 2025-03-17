def range_bitwise_and(m, n):
    # Count the number of shifts needed to make m and n equal
    shift = 0
    while m < n:
        m >>= 1
        n >>= 1
        shift += 1
    
    # Shift back to get the common prefix
    return m << shift