using DSA.Exceptions;
using DSA.Stacks;

namespace DSA.InfixToPostfix;
public class InfixConverter
{
    public string ConvertToPostfix(string equation)
    {
        bool isValid = HasValidParenthesis(equation);
        if (!isValid)
        {
            throw new InvalidParenthesisException();
        }

        CustomStack<char> stack = new(equation.Length);

        string postfix = "";

        for (int i = 0; i < equation.Length; i++)
        {
            char c = equation[i];

            if (IsDigit(c))
            {
                postfix += c;
            }

            else if (IsOpenParenthesis(c))
            {
                stack.Push(c);
            }
            else if (IsClosedParenthesis(c))
            {
               
                while (!stack.IsEmpty() && !IsOpenParenthesis(stack.Peek()))
                {
                    postfix += stack.Pop();

                }
                if (!stack.IsEmpty() && IsOpenParenthesis(stack.Peek()))
                {
                    stack.Pop();
                }
                
            }
            else if (IsOperator(c))
            {
                while (!stack.IsEmpty() && IsOperator(stack.Peek()) && !HasGreaterPrecedence(c, stack.Peek()))
                {
                    postfix += stack.Pop();
                }

                stack.Push(c);
            }
        }

        while (!stack.IsEmpty())
        {
            if (IsOperator(stack.Peek()))
            {
                postfix += stack.Pop();
            }
        }

        return postfix;
    }

    public bool HasValidParenthesis(string equation)
    {
        int openCount = 0;
        int closedCount = 0;

        foreach (char c in equation)
        {
            if (c == '(')
            {
                openCount++;
            }
            else if (c == ')')
            {
                closedCount++;
            }
        }

        return openCount == closedCount;
    }

    public bool IsDigit(char c)
    {
        return c >= '0' && c <= '9';
    }
    public bool IsOperator(char c)
    {
        char[] operators =
        {
            '+',
            '-',
            '^',
            '*',
            '/'
        };
        return operators.Contains(c);
    }
    public bool IsOpenParenthesis(char c)
    {
        return c == '(';
    }
    public bool IsClosedParenthesis(char c)
    {
        return c == ')';
    }

    public bool HasGreaterPrecedence(char op, char opToCompare)
    {
        if (op != opToCompare)
        {
            if (op == '^')
            {
                return true;
            }

            if (op == '*')
            {
                if (opToCompare != '^')
                {
                    return true;
                }
                return false;
            }
            if (op == '/')
            {
                if (opToCompare != '*' || opToCompare != '^')
                {
                    return true;
                }
                return false;
            }
            if (op == '+')
            {
                if (opToCompare != '-')
                {
                    return true;
                }
                return false;
            }
            if (op == '-')
            {
                return false;
            }
        }
        return false;
    }

    public float EvaluateOperator(float a, float b, char op)
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
            return (int) Math.Pow(a, b);
        }
        return int.MinValue;
    }

    public float EvaluatePostfix(string equation)
    {
        CustomStack<float> stack = new(equation.Length);
        for (int i = 0; i < equation.Length; i++) 
        {

            if (IsOperator(equation[i]))
            {
                float a = stack.Pop();
                float b = stack.Pop();

                float res = EvaluateOperator(a, b, equation[i]);
                stack.Push(res);
            } else
            {
                stack.Push(equation[i] - '0');
            }
        }
        return stack.Pop();
    }
}
