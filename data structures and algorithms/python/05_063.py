# Optimized Valid Anagram
def is_anagram_optimized(s, t):
    return Counter(s) == Counter(t)  # Clean but mention the tradeoffs!