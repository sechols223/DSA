namespace DSA.Sorting;

public class Sorter
{

    public async Task Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int i = Partition(arr, low, high);
            
            
            Task task1 = Task.Run(() => Sort(arr, low, i - 1));
            Task task2 = Task.Run(() => Sort(arr, i + 1, high));

            await Task.WhenAll(task1, task2);
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
}