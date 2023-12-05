namespace DSA.Heaps;

public class Heap
{
    

    public void Build(int[] nums)
    {
        int[] tree = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            tree[i] = num;
            Heapify(nums, num);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tree"></param>
    /// <param name="leaf"></param>
    private void Heapify(int[] tree, int leaf)
    {
        if (leaf > 1)
        {
            int parent = leaf / 2;
            if (tree[leaf] > tree[parent])
            {
                Swap(tree, leaf, parent);
                Heapify(tree, leaf);
            }
        }
    }

    private void Swap(int[] arr, int a, int b)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
}