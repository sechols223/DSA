using DSA.Common;
using DSA.Exceptions;
using DSA.Stacks;

namespace DSA.InfixToPostfix;
public class InfixConverter
{
    public string ConvertToPostfix(string equation)
    {
        bool isValid = EquationHelper.HasValidParenthesis(equation);
        if (!isValid)
        {
            throw new InvalidParenthesisException();
        }

        CustomStack<char> stack = new(equation.Length);

        string postfix = "";

        for (int i = 0; i < equation.Length; i++)
        {
            char c = equation[i];

            if (EquationHelper.IsDigit(c))
            {
                postfix += c;
            }

            else if (EquationHelper.IsOpenParenthesis(c))
            {
                stack.Push(c);
            }
            else if (EquationHelper.IsClosedParenthesis(c))
            {
               
                while (!stack.IsEmpty() && !EquationHelper.IsOpenParenthesis(stack.Peek()))
                {
                    postfix += stack.Pop();

                }
                if (!stack.IsEmpty() && EquationHelper.IsOpenParenthesis(stack.Peek()))
                {
                    stack.Pop();
                }
                
            }
            else if (EquationHelper.IsOperator(c))
            {
                while (!stack.IsEmpty() && EquationHelper.IsOperator(stack.Peek()) && !HasGreaterPrecedence(c, stack.Peek()))
                {
                    postfix += stack.Pop();
                }

                stack.Push(c);
            }
        }

        while (!stack.IsEmpty())
        {
            if (EquationHelper.IsOperator(stack.Peek()))
            {
                postfix += stack.Pop();
            }
        }

        return postfix;
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


    public double EvaluatePostfix(string equation)
    {
        CustomStack<double> stack = new(equation.Length);
        for (int i = 0; i < equation.Length; i++) 
        {

            if (EquationHelper.IsOperator(equation[i]))
            {
                double a = stack.Pop();
                double b = stack.Pop();

                double res = EquationHelper.EvaluateOperator(a, b, equation[i]);
                stack.Push(res);
            } else
            {
                stack.Push(equation[i] - '0');
            }
        }
        return stack.Pop();
    }
}
