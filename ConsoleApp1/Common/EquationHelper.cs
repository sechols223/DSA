using DSA.Stacks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Common;
public static class EquationHelpers
{
    public static bool HasValidParenthesis(string equation)
    {
        if (string.IsNullOrEmpty(equation))
        {
            return true;
        }
        CustomStack<char> stack = new(equation.Length);

        for (int i = 0; i < equation.Length; i++)
        {
            char c = equation[i];

            if (c == '(' || c == '[')
            {
                stack.Push(c);
            }
            else
            {
                if (c == ')')
                {
                    if (stack.IsEmpty() || stack.Pop() != '(')
                    {
                        return false;
                    }
                }
                if (c == ']')
                {
                    if (stack.IsEmpty() || stack.Pop() != '[')
                    {
                        return false;
                    }
                }
            }
        }
        bool hasOpenLeftInStack = stack.IsEmpty();

        return hasOpenLeftInStack;
    }
    public static bool IsOpenParenthesis(char c)
    {
        return c == '(' || c == '[';
    }
    public static bool IsClosedParenthesis(char c)
    {
        return c == ')' || c == ']';
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

    public static bool IsDigit(char c)
    {
        return c >= '0' && c <= '9';
    }
    public static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '^' || c == '*' || c == '/';
    }
}
