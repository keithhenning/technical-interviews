def generate_bracket_expressions(expr):

    result = set()
    brackets = ["()", "[]", "{}"]
    
    # Check if we can insert a bracket pair at each position
    for i in range(len(expr) + 1):
        for bracket in brackets:
            new_expr = expr[:i] + bracket[0] + expr[i:]
            
            # Try all positions for the closing bracket
            for j in range(i + 1, len(new_expr) + 1):
                candidate = new_expr[:j] + bracket[1] + new_expr[j:]
                if is_valid(candidate):
                    result.add(candidate)
    
    # Add each type of bracket pair around the entire expression
    for bracket in brackets:
        result.add(bracket[0] + expr + bracket[1])
    
    return list(result)

def is_valid(expr):
    stack = []
    bracket_map = {")": "(", "]": "[", "}": "{"}
    
    for char in expr:
        if char in "([{":
            stack.append(char)
        elif char in ")]}":
            if not stack or stack.pop() != bracket_map[char]:
                return False
    
    return len(stack) == 0