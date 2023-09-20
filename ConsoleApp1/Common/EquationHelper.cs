using DSA.Stacks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common;
public static class EquationHelper
{
    public static bool HasValidParenthesis(string equation)
    {
        int length = equation.Length; 

        if (length <= 0)
        {
            return true;
        }

        CustomStack<char> stack = new(length);

        bool isValid = true;

        for (int i = 0; i < length; i++)
        {
            char c = equation[i];
            if (IsOpenParenthesis(c))
            {
                stack.Push(c);
            } 
            else if (IsClosedParenthesis(c))
            {
                if (stack.IsEmpty() || !ParenthesisMatch(c, stack.Peek())) 
                {
                    return false;
                }

                stack.Pop();
            }
            
        }
        return isValid;
    }

    public static bool IsDigit(char c)
    {
        return c >= '0' && c <= '9';
    }
    public static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '^' || c == '*' || c == '/'; 
    }
    public static bool IsOpenParenthesis(char c)
    {
        char parenthesis = (char)('(' | '[');
        return c == parenthesis;
    }
    public static bool IsClosedParenthesis(char c)
    {
        char parenthesis = (char)(')' | ']');
        return c == parenthesis;
    }

    public static double EvaluateOperator(double a, double b, char op)
    {
        if (op == '+')
        {
            return a + b;
        }
        if (op == '-')
        {
            return a - b;
        }
        if (op == '*')
        {
            return a * b;
        }
        if (op == '/')
        {
            return a / b;
        }
        if (op == '^')
        {
            Math.Pow(a, b);
        }
        return double.MinValue;
    }

    private static bool ParenthesisMatch(char opening, char closing)
    {
        return (opening == '(' && closing == ')') || (opening == '[' && closing == ']');
    }
}
