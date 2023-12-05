using DSA.Common;
using DSA.HashTables;

namespace Tests.HashTableTests;

[TestClass]
public class HashTableTest
{
    [TestMethod]
    public void Test()
    {
        const string PATH = "Data/hash-names.txt";
        FileReader reader = new(PATH);

        string[] names = reader.ReadLines();
        HashTable table = new(names);
        table.PrintTable();
    }
}