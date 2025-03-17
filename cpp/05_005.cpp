std::string pop() {
    if (!isEmpty()) {
        std::string top = stack.back();
        stack.pop_back();
        return top;
    }
    return ""; // Return empty string for empty stack
}