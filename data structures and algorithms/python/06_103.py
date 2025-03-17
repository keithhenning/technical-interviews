# Flip bits from position i to j
def flip_bits_in_range(n, i, j):
    # Create mask with 1s from position i to j
    mask = ((1 << (j - i + 1)) - 1) << i
    return n ^ mask