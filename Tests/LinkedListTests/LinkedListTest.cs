using DSA.Common;

namespace Tests.LinkedListTests;

[TestClass]
public class LinkedListTest
{

    [TestMethod]
    public void FindAt_Pass()
    {

        DSA.LinkedLists.LinkedList<int> list = new();
        list.Insert(12);
        list.Insert(14);
        list.Insert(15);

        int data1 = list.FindAt(0);
        int data2 = list.FindAt(1);
        int data3 = list.FindAt(2);

        Assert.AreEqual(12, data1);
        Assert.AreEqual(14, data2);
        Assert.AreEqual(15, data3);
    }

    [TestMethod]
    public void InsertAt_Pass()
    {
        DSA.LinkedLists.LinkedList<int> list = new();
        
        list.Insert(12);
        list.Insert(14);
        list.Insert(15);

        list.InsertAfter(0, 13);

        int data1 = list.FindAt(0);
        int data2 = list.FindAt(1);
        int data3 = list.FindAt(2);
        int data4 = list.FindAt(3);

        Assert.AreEqual(12, data1);
        Assert.AreEqual(13, data2);
        Assert.AreEqual(14, data3);
        Assert.AreEqual(15, data4);

    }

    [TestMethod]
    public void InsertNames()
    {
        DSA.LinkedLists.LinkedList<string> list = new();

        string path = "Data/names.txt";
        FileReader fileReader = new(path);

        string[] lines = fileReader.ReadLines();

        foreach (string line in lines)
        {
            list.InsertOrdered(line);

        }

        list.PrintList();
        Assert.IsTrue(list.Length > 0);
    }
}
