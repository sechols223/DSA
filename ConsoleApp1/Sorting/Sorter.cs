using DSA.Trees;

namespace DSA.Sorting;

public class Sorter
{
    public void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int i = Partition(arr, low, high);

            Sort(arr, low, i - 1);
            Sort(arr, i + 1, high);
            
        }
    }

    public int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        
        int i = low - 1;

        for (int j = low; j <= high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr,j, i);
            }
        }  
        Swap(arr, i + 1, high);
        return i + 1;
    }

    public void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void TreeSort(int[] data, bool doPrint = true)
    {
        BinaryTree tree = new();
        tree.BuildTree(data);
        tree.Traverse(doPrint);
    }

    public static void BubbleSort(int[] data, bool doPrint = true)
    {
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data.Length; j++)
            {
                if (data[j] < data[i])
                {
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }
        }

        if (doPrint)
        {
            foreach (int number in data)
            {
                Console.WriteLine(number);
            }
        }
    }
}