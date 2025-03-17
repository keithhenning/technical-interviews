bool is_balanced(const std::string& expression) {
    std::stack<char> stack;
    std::unordered_map<char, char> pairs = {
        {')', '('},
        {'}', '{'},
        {']', '['}
    };
    
    for (char ch : expression) {
        if (ch == '(' || ch == '{' || ch == '[') {
            stack.push(ch);
        } else if (ch == ')' || ch == '}' || ch == ']') {
            if (stack.empty() || stack.top() != pairs[ch]) {
                return false;
            }
            stack.pop();
        }
    }
    
    return stack.empty();
}