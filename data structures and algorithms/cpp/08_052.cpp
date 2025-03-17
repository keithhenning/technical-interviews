#include <string>
#include <vector>
#include <set>
#include <stack>
#include <unordered_map>

class Solution {
public:
    std::vector<std::string> generateBracketExpressions(
            const std::string& expr) {
        std::set<std::string> result;
        std::vector<std::string> brackets = {"()", "[]", "{}"};
        
        // Check if we can insert a bracket pair at each position
        for (int i = 0; i <= expr.length(); i++) {
            for (const auto& bracket : brackets) {
                std::string newExpr = expr.substr(0, i) + 
                                     bracket[0] + 
                                     expr.substr(i);
                
                // Try all positions for the closing bracket
                for (int j = i + 1; j <= newExpr.length(); j++) {
                    std::string candidate = newExpr.substr(0, j) + 
                                           bracket[1] + 
                                           newExpr.substr(j);
                    if (isValid(candidate)) {
                        result.insert(candidate);
                    }
                }
            }
        }
        
        // Add each type of bracket pair around the entire expr
        for (const auto& bracket : brackets) {
            result.insert(bracket[0] + expr + bracket[1]);
        }
        
        return std::vector<std::string>(
                result.begin(), result.end());
    }
    
private:
    bool isValid(const std::string& expr) {
        std::stack<char> stack;
        std::unordered_map<char, char> bracketMap = {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };
        
        for (char c : expr) {
            if (c == '(' || c == '[' || c == '{') {
                stack.push(c);
            } else if (c == ')' || c == ']' || c == '}') {
                if (stack.empty() || 
                    stack.top() != bracketMap[c]) {
                    return false;
                }
                stack.pop();
            }
        }
        
        return stack.empty();
    }
};