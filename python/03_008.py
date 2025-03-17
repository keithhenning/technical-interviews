def get_permutations(string):
    # Base case
    if len(string) <= 1:
        return [string]
    
    # Recursive case
    perms = []
    for i in range(len(string)):
        char = string[i]
        remaining = string[:i] + string[i+1:]
        
        for p in get_permutations(remaining):
            perms.append(char + p)
            
    return perms

# Example usage
result = get_permutations("abc")
print(result)  # ['abc', 'acb', 'bac', 'bca', 'cab', 'cba']