def first_uniq_char(s):

    # Count the occurrences of each character
    char_count = {}
    for char in s:
        char_count[char] = char_count.get(char, 0) + 1
    
    # Find the first character with count 1
    for i, char in enumerate(s):
        if char_count[char] == 1:
            return i
    
    return -1  # No unique character found

# Example usage
print(first_uniq_char("apple"))      # 0
print(first_uniq_char("loveapples"))  # 1
print(first_uniq_char("aabb"))        # -1