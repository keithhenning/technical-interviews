def evaluate_expression(expr):

    def evaluate(index):
        char = expr[index]
        
        # Check if it's an operand (letter)
        if 'a' <= char <= 'z':
            return ord(char) - ord('a') + 1, index + 1
        
        # It's an operator, evaluate the two operands
        left_val, next_index = evaluate(index + 1)
        right_val, next_index = evaluate(next_index)
        
        # Apply the operator
        if char == '+':
            return left_val + right_val, next_index
        elif char == '-':
            return left_val - right_val, next_index
        elif char == '*':
            return left_val * right_val, next_index
        elif char == '/':
            return left_val // right_val, next_index
        elif char == '&#x24;':
            return max(left_val, right_val), next_index
        elif char == '&':
            return min(left_val, right_val), next_index
        
    result, _ = evaluate(0)
    return result