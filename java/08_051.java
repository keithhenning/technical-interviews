class Solution {
    private int index;
    
    public int evaluateExpression(String expr) {
        index = 0;
        return evaluate(expr);
    }
    
    private int evaluate(String expr) {
        char ch = expr.charAt(index);
        index++;
        
        // Check if it's an operand (letter)
        if (ch >= 'a' && ch <= 'z') {
            return ch - 'a' + 1;
        }
        
        // It's an operator, evaluate the two operands
        int leftVal = evaluate(expr);
        int rightVal = evaluate(expr);
        
        // Apply the operator
        switch (ch) {
            case '+': return leftVal + rightVal;
            case '-': return leftVal - rightVal;
            case '*': return leftVal * rightVal;
            case '/': return leftVal / rightVal;
            case '$': return Math.max(leftVal, rightVal);
            case '&': return Math.min(leftVal, rightVal);
            default: return 0; // Should not reach here
        }
    }
}