def evalRPN(tokens):

    stack = []
    
    for token in tokens:
        if token in ["+", "-", "*", "/", "^"]:
            b = stack.pop()
            a = stack.pop()
            
            if token == "+":
                stack.append(a + b)
            elif token == "-":
                stack.append(a - b)
            elif token == "*":
                stack.append(a * b)
            elif token == "/":
                # Integer division that truncates towards zero
                stack.append(int(a / b))
            elif token == "^":
                stack.append(a ** b)
        else:
            stack.append(int(token))
    
    return stack[0]