using DSA.Common;

namespace Tests.CommonTests;

[TestClass]
public class EquationHelperTests
{
    [TestMethod]
    [TestCategory("Equation Helper")]
    [DataRow('a')]
    [DataRow('b')]
    [DataRow('c')]
    public void IsDigit_False(char value)
    {
        bool isDigit = EquationHelpers.IsDigit(value);
        Assert.IsFalse(isDigit);
    }
    [TestMethod]
    [TestCategory("Equation Helper")]
    [DataRow('1')]
    [DataRow('2')]
    [DataRow('3')]
    public void IsDigit_True(char value)
    {
        bool isDigit = EquationHelpers.IsDigit(value);
        Assert.IsTrue(isDigit);
    }

    [TestMethod]
    [TestCategory("Equation Helper")]
    [DataRow("((1+2))")]
    [DataRow("(1+2) + (3)")]
    [DataRow("1+2")]
    [DataRow("[1+2]")]

    public void HasValidParenthesis_True(string value)
    {
        bool isValid = EquationHelpers.HasValidParenthesis(value);
        Assert.IsTrue(isValid);
    }
    [TestMethod]
    [TestCategory("Equation Helper")]
    [DataRow("(1+2))")]
    [DataRow("(1+2 + (3)")]
    [DataRow("1+2)")]
    [DataRow("[1+2)")]

    public void HasValidParenthesis_False(string value)
    {
        bool isValid = EquationHelpers.HasValidParenthesis(value);
        Assert.IsFalse(isValid);
    }

    [TestMethod]
    [TestCategory("Equation Helper")]
    [DataRow('1')]
    [DataRow('2')]
    [DataRow('3')]
    public void IsOperator_False(char value)
    {
        bool isValid = EquationHelpers.IsOperator(value);
        Assert.IsFalse(isValid);
    }
    [TestMethod]
    [TestCategory("Equation Helper")]
    [DataRow('+')]
    [DataRow('-')]
    [DataRow('*')]
    public void IsOperator_True(char value)
    {
        bool isValid = EquationHelpers.IsOperator(value);
        Assert.IsTrue(isValid);
    }
}
