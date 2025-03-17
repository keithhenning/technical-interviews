#include <vector>
#include <string>
#include <stack>
#include <cmath>
using namespace std;

class Solution {
public:
    // Evaluate Reverse Polish Notation expression
    int evalRPN(vector<string>& tokens) {
        // Stack to store operands
        stack<int> s;
        
        // Process each token
        for (string& token : tokens) {
            // Check if token is an operator
            if (token == "+" || token == "-" || token == "*" || 
                token == "/" || token == "^") {
                // Pop the top two operands
                int b = s.top(); s.pop();
                int a = s.top(); s.pop();
                
                // Perform operation based on operator
                if (token == "+") {
                    s.push(a + b);
                } 
                else if (token == "-") {
                    s.push(a - b);
                } 
                else if (token == "*") {
                    s.push(a * b);
                } 
                else if (token == "/") {
                    s.push(a / b);
                } 
                else if (token == "^") {
                    s.push(pow(a, b));
                }
            } 
            // If token is a number, push to stack
            else {
                s.push(stoi(token));
            }
        }
        
        // Return the final result
        return s.top();
    }
};