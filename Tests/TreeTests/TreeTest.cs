using DSA.Common;
using DSA.Trees;

namespace Tests.TreeTests;

[TestClass]
public class TreeTest
{
    
    [TestMethod]
    public void BuildTree_Pass()
    {
        const string path = "Data/numbers.txt";

        FileReader fileReader = new(path);
        int[] numbers = fileReader.ReadLinesAsInt();
        
        BinaryTree tree = new();
        
        tree.BuildTree(numbers);
    }

    [TestMethod]
    public void Traverse_Pass()
    {
        const string path = "Data/numbers.txt";

        FileReader fileReader = new(path);
        int[] numbers = fileReader.ReadLinesAsInt();
        BinaryTree tree = new();
        
        tree.BuildTree(numbers);
        tree.Traverse();
    }
}