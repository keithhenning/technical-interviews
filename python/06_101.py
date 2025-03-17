def xor_from_0_to_n(n):
    """Compute XOR of all numbers from 0 to n without loop"""
    remainder = n % 4
    if remainder == 0:
        return n
    elif remainder == 1:
        return 1
    elif remainder == 2:
        return n + 1
    else:  # remainder == 3
        return 0