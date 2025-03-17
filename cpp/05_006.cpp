std::string peek() {
    if (!isEmpty()) {
        return stack.back();
    }
    return ""; // Return empty string for empty stack
}