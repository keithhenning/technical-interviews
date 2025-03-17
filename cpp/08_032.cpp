#include <vector>
#include <stack>

std::vector<int> daysUntilWarmer(
    std::vector<int>& temperatures) {
    
    int n = temperatures.size();
    std::vector<int> result(n, 0);
    std::stack<int> stack;
    
    for (int i = 0; i < n; i++) {
        while (!stack.empty() && 
               temperatures[i] > temperatures[stack.top()]) {
            int prev = stack.top();
            stack.pop();
            result[prev] = i - prev;
        }
        stack.push(i);
    }
    
    return result;
}