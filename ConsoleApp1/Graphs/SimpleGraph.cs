using DSA.Stacks;

namespace DSA.Graphs;

public class SimpleGraph
{
    private int _vertices;
    private LinkedLists.LinkedList<int>[] adjacencyMatrix;

    public SimpleGraph(int vertices)
    {
        adjacencyMatrix = new LinkedLists.LinkedList<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {

            adjacencyMatrix[i] = new LinkedLists.LinkedList<int>();
        }

        _vertices = vertices;
    }

    public void AddEdge(int vertex, int data)
    {
        adjacencyMatrix[vertex].Insert(data);
    }

    public void BreadthFirstTraversal(int node)
    {
        Console.WriteLine("---BFT---");
        bool[] visited = CreateVisitedArray();
        
        Queue<int> queue = new();
        visited[node] = true;
        queue.Enqueue(node);
        
        while (queue.Count > 0)
        {
            node = queue.Dequeue();
            Console.WriteLine($"{node} ");
            LinkedLists.LinkedList<int> list = adjacencyMatrix[node];

            for (int i = 0; i < list.Length; i++)
            {
                int value = list.FindAt(i);
                if (!visited[value])
                {
                    visited[value] = true;
                    queue.Enqueue(value);
                }
            }
        }
        Console.WriteLine("---------");
    }

    private void SetVisitedBft(int n, bool[] visited)
    {
        LinkedLists.LinkedList<int> list = adjacencyMatrix[n];
        
    }
    
    public void DepthFirstTraversal(int node)
    {
        Console.WriteLine("---DFT---");
        bool[] visited = CreateVisitedArray();
        SetVisitedDft(node, visited);
        Console.WriteLine("---------");
    }

    private bool[] CreateVisitedArray()
    {
        bool[] visited = new bool[_vertices];
        for (int i = 0; i < _vertices; i++)
        {
            visited[i] = false;
        }
        return visited;
    }

    private void SetVisitedDft(int v, bool[] visited)
    {
        visited[v] = true;
        Console.WriteLine($"{v}");
        LinkedLists.LinkedList<int> list = adjacencyMatrix[v];

        for (int i = 0; i < list.Length; i++)
        {
            if (!visited[i])
            {
                SetVisitedDft(i, visited);
            }
        }
    }
}