def count_bits_to_flip(a, b):
    # XOR gives 1 for bits that are different
    xor_result = a ^ b
    # Count the set bits in the XOR result
    return count_set_bits(xor_result)