# Check if n is one less than a power of 2
def is_one_less_than_power_of_two(n):
    return n > 0 and (n & (n + 1)) == 0