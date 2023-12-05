
using BenchmarkDotNet.Running;



#if RELEASE
BenchmarkRunner.Run<Sorting>();
#endif

#if DEBUG
using Benchmarks;
using DSA.Common;

FileReader reader = new(FilePaths.Numbers);
int[] lines = reader.ReadLinesAsInt();

Console.WriteLine($"Lines: {lines.Length}");

#endif