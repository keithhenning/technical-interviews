#include <stack>

std::stack<std::string> stack;
stack.push("first");  // Add element
stack.push("second");
std::string top = stack.top(); // View top element
stack.pop(); // Remove top element (returns void)
bool empty = stack.empty();