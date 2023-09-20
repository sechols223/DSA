using DSA.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CommonTests;

[TestClass]
public class IndexerTests
{

    [TestMethod]
    [DataRow('a', 0)]
    [DataRow('b', 1)]
    [DataRow('c', 2)]
    public void GetCharValue_Pass(char c, int value)
    {
        Indexer indexer = new();
        int val = indexer.GetCharValue(c);
        Assert.IsTrue(val == value);
    }

    [TestMethod]
   
    public void GetStringValue_Pass() 
    { 
        Indexer indexer = new();
        int val1 = indexer.GetStringValue("joe");
        int val2 = indexer.GetStringValue("mary");

        Assert.IsTrue(val1 < val2);
    }
}
