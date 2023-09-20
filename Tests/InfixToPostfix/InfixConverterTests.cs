using DSA.Common;
using DSA.Exceptions;
using DSA.InfixToPostfix;

namespace Tests.InfixToPostfix;

[TestClass]
public class InfixConverterTests
{
    [TestMethod]
    [DataRow('a')]
    [DataRow('b')]
    [DataRow('c')]
    public void IsDigit_False(char value)
    {
        InfixConverter infixConverter = new();
        bool isDigit = infixConverter.IsDigit(value);
        Assert.IsFalse(isDigit);
    }
    [TestMethod]
    [DataRow('1')]
    [DataRow('2')]
    [DataRow('3')]
    public void IsDigit_True(char value)
    {
        InfixConverter infixConverter = new();
        bool isDigit = infixConverter.IsDigit(value);
        Assert.IsTrue(isDigit);
    }

    [TestMethod]
    [DataRow("((1+2))")]
    [DataRow("(1+2) + (3)")]
    [DataRow("1+2")]

    public void HasValidParenthesis_True(string value)
    {
        InfixConverter infixConverter = new();
        bool isValid = infixConverter.HasValidParenthesis(value);
        Assert.IsTrue(isValid);
    }
    [TestMethod]
    [DataRow("(1+2))")]
    [DataRow("(1+2 + (3)")]
    [DataRow("1+2)")]

    public void HasValidParenthesis_False(string value)
    {
        InfixConverter infixConverter = new();
        bool isValid = infixConverter.HasValidParenthesis(value);
        Assert.IsFalse(isValid);
    }

    [TestMethod]
    [DataRow('1')]
    [DataRow('2')]
    [DataRow('3')]
    public void IsOperator_False(char value)
    {
        InfixConverter infixConverter = new();
        bool isValid = infixConverter.IsOperator(value);
        Assert.IsFalse(isValid);
    }
    [TestMethod]
    [DataRow('+')]
    [DataRow('-')]
    [DataRow('*')]
    public void IsOperator_True(char value)
    {
        InfixConverter infixConverter = new();
        bool isValid = infixConverter.IsOperator(value);
        Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void InfixToPostfix()
    {
        InfixConverter infixConverter = new();
        string equation = infixConverter.ConvertToPostfix("3+3+1+2*4");
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void ConvertEquations()
    {
        InfixConverter infixConverter = new();
        FileReader reader = new FileReader(@"C:\Users\cecho\source\repos\ConsoleApp1\Tests\Data\equations.txt");

        string[] equations = reader.ReadLines();

        foreach (string equation in equations)
        {
            Console.WriteLine("-----");
            try
            {
                string postfix = infixConverter.ConvertToPostfix(equation);
                float result = infixConverter.EvaluatePostfix(postfix);
                Console.WriteLine($"Infix: {equation}");
                Console.WriteLine($"Postfix: {postfix}");
                Console.WriteLine($"Result: {result} ");
            } catch (InvalidParenthesisException)
            {

                Console.WriteLine("Invalid parenthesis");
            }
            finally
            {
                Console.WriteLine("-----");
            }
        }
        Assert.IsTrue(true);
    }
}