#include <string>
#include <algorithm> // for max/min

class Solution {
public:
    int evaluateExpression(std::string expr) {
        int index = 0;
        return evaluate(expr, index);
    }
    
private:
    int evaluate(const std::string& expr, int& index) {
        char ch = expr[index++];
        
        // Check if it's an operand (letter)
        if (ch >= 'a' && ch <= 'z') {
            return ch - 'a' + 1;
        }
        
        // It's an operator, evaluate the two operands
        int leftVal = evaluate(expr, index);
        int rightVal = evaluate(expr, index);
        
        // Apply the operator
        switch (ch) {
            case '+': return leftVal + rightVal;
            case '-': return leftVal - rightVal;
            case '*': return leftVal * rightVal;
            case '/': return leftVal / rightVal;
            case '&#x24;': return std::max(leftVal, rightVal);
            case '&': return std::min(leftVal, rightVal);
            default: return 0; // Should not reach here
        }
    }
};