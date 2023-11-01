
using DSA.Graphs;
using DSA.LinkedLists;
using DSA.Sorting;

public class Program
{
    public static void Main(string[] args)
    {
        // ScaryLinkedListMenu menu = new();
        // menu.Start();

        SimpleGraph graph = new(4);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 3);
        
        graph.BreadthFirstTraversal(2);
        graph.DepthFirstTraversal(2);
    }
    
}