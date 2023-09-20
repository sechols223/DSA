using DSA.Common;
using DSA.Exceptions;
using DSA.InfixToPostfix;

namespace Tests.InfixToPostfix;

[TestClass]
public class InfixConverterTests
{
   

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