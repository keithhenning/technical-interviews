#include <iostream>
#include <vector>
#include <stack>

std::vector<int> dailyTemperatures(
        const std::vector<int>& temperatures) {
    int n = temperatures.size();
    std::vector<int> result(n, 0);
    std::stack<int> stack;
    
    for (int i = 0; i < n; i++) {
        while (!stack.empty() && 
               temperatures[i] > temperatures[stack.top()]) {
            int prevDay = stack.top();
            stack.pop();
            result[prevDay] = i - prevDay;
        }
        stack.push(i);
    }
    
    return result;
}

int main() {
    std::vector<int> temps = {73, 74, 75, 71, 69, 72, 76, 73};
    std::vector<int> result = dailyTemperatures(temps);
    
    std::cout << "[";
    for (int i = 0; i < result.size(); i++) {
        std::cout << result[i];
        if (i < result.size() - 1) {
            std::cout << ", ";
        }
    }
    std::cout << "]" << std::endl;
    // Output: [1, 1, 4, 2, 1, 1, 0, 0]
    
    return 0;
}