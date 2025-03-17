def longest_palindrome(s: str) -> str:

    if not s:
        return ""
    
    start = 0
    max_length = 1
    
    # Helper function to expand around center
    def expand_around_center(left, right):
        nonlocal start, max_length
        while (left >= 0 and right < len(s) and 
               s[left] == s[right]):
            current_length = right - left + 1
            if current_length > max_length:
                max_length = current_length
                start = left
            left -= 1
            right += 1
    
    # Check each position as potential center
    for i in range(len(s)):
        # Odd length palindromes (like "aba")
        expand_around_center(i, i)
        # Even length palindromes (like "abba")
        expand_around_center(i, i + 1)
    
    return s[start:start + max_length]

# Example usage
print(longest_palindrome("babad"))  # "bab" or "aba"
print(longest_palindrome("cbbd"))   # "bb"