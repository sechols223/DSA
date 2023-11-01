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
        
        int val = Indexer.GetCharValue(c);
        Assert.IsTrue(val == value);
    }

    [TestMethod]
   
    public void GetStringValue_Pass() 
    { 
        
        int val1 = Indexer.GetStringValue("joe");
        int val2 = Indexer.GetStringValue("mary");

        Assert.IsTrue(val1 < val2);
    }
}
