
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Benchmarks;
using Bogus;
using DSA.Common;
using DSA.HashTables;
using DSA.Sorting;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, iterationCount: 5, launchCount: 1)]
public class Sorting
{
    private int[]? numbers;
    private string[]? names;
    public void TreeSort()
    {
        if (numbers == null || numbers.Length == 0)
        {
            FileReader reader = new(FilePaths.Numbers);
            numbers = reader.ReadLinesAsInt();
        }

        Sorter.TreeSort(numbers, false);
    }

    public void BubbleSort()
    {
        if (numbers == null || numbers.Length == 0)
        {
            FileReader reader = new(FilePaths.Numbers);
            numbers = reader.ReadLinesAsInt();
        }
        
        Sorter.BubbleSort(numbers, false);
    }
}