using System;
using System.Collections.Generic;

public class Solution
{
    public bool IsBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> pairs = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

        foreach (char c in expression)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0 || stack.Pop() != pairs[c])
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
