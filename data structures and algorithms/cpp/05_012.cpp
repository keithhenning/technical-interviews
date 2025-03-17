#include <iostream>
#include <deque>
#include <string>

int main() {
    try {
        std::deque<std::string> stack;
        // In C++, pop() doesn't throw on empty containers
        // Need to check explicitly
        if (stack.empty()) {
            throw std::runtime_error("Empty stack");
        }
        stack.pop_front();
    } catch (const std::runtime_error& e) {
        std::cout << "Handle empty stack!" << std::endl;
    }
    
    return 0;
}