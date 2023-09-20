using DSA.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CommonTests;

[TestClass]
public class FileReaderTests
{

    [TestMethod]
    public void ReadFile_Pass()
    {
        string path = @"C:\Users\cecho\source\repos\ConsoleApp1\Tests\Data\names.txt";
        FileReader fileReader = new FileReader(path);
        string[] lines = fileReader.ReadLines();

        Assert.IsFalse(lines.Length <= 0);
    }
}
