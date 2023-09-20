using DSA.Common;
using DSA.Exceptions;
using DSA.Stacks;

using System.Text;

namespace DSA.InfixToPostfix;
public class InfixConverter
{
    public string ConvertToPostfix(string equation)
    {
        bool isValid = EquationHelpers.HasValidParenthesis(equation);
        if (!isValid)
        {
            throw new InvalidParenthesisException();
        }

        CustomStack<char> stack = new(equation.Length);
        StringBuilder stringBuilder = new();

        for (int i = 0; i < equation.Length; i++)
        {
            char c = equation[i];

            if (EquationHelpers.IsDigit(c))
            {
                stringBuilder.Append(c);
            }

            else if (EquationHelpers.IsOpenParenthesis(c))
            {
                stack.Push(c);
            }
            else if (EquationHelpers.IsClosedParenthesis(c))
            {
               
                while (!stack.IsEmpty() && !EquationHelpers.IsOpenParenthesis(stack.Peek()))
                {
                    stringBuilder.Append(stack.Pop());

                }
                if (!stack.IsEmpty() && EquationHelpers.IsOpenParenthesis(stack.Peek()))
                {
                    stack.Pop();
                }
                
            }
            else if (EquationHelpers.IsOperator(c))
            {
                while (!stack.IsEmpty() &&
                    EquationHelpers.IsOperator(stack.Peek()) && 
                    !HasGreaterPrecedence(c, stack.Peek()))
                {
                    stringBuilder.Append(stack.Pop());
                }

                stack.Push(c);
            }
        }

        while (!stack.IsEmpty())
        {
            if (EquationHelpers.IsOperator(stack.Peek()))
            {
                stringBuilder.Append(stack.Pop());
            }
        }

        return stringBuilder.ToString();
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

            if (EquationHelpers.IsOperator(equation[i]))
            {
                double a = stack.Pop();
                double b = stack.Pop();

                double res = EquationHelpers.EvaluateOperator(a, b, equation[i]);
                stack.Push(res);
            } 
            else
            {
                stack.Push(equation[i] - '0');
            }
        }
        return stack.Pop();
    }
}
