using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Exceptions;
public sealed class InvalidParenthesisException : Exception
{

    public InvalidParenthesisException()
    {

    }

    public InvalidParenthesisException(string property) :
        base($"{property}: This equation does not have valid parenthesis")
    {

    }
}
