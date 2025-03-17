def add_without_plus(a, b):
    while b != 0:
        # Carry is AND, shifted by 1
        carry = (a & b) << 1
        # Sum is XOR
        a = a ^ b
        b = carry
    return a