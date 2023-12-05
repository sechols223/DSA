namespace DSA.Trees;

public class BinaryTree
{
    private TreeNode? root;
    public  void BuildTree(int[] data)
    {
        int length = data.Length;
        for (int i = 0; i < length; i++)
        {
            if (root == null)
            {
                root = new TreeNode(data[i]);
            }

            bool searching = true;
            TreeNode current = root;
            while (searching)
            {
                if (data[i] > current.data)
                {
                    
                    if (current.right == null)
                    {
                        current.right = new TreeNode(data[i]);
                        searching = false;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
                else if (data[i] < current.data)
                {
                    if (current.left == null)
                    {
                        current.left = new TreeNode(data[i]);
                        searching = false;
                    }
                    else
                    {
                        current = current.left;
                    }
                }
                else
                {
                    searching = false;
                }
            }
        }
    }
    
    public void Traverse(bool doPrint = true)
    {
        if (!doPrint)
        {
            TraverseNoPrint(root);
        }
        else
        {
            Traverse(root);
        }
    }

    private void TraverseNoPrint(TreeNode? node)
    {
        while (true)
        {
            if (node != null)
            {
                TraverseNoPrint(node.left);
                node = node.right;
                continue;
            }

            break;
        }
    }

    private void Traverse(TreeNode? node)
    {
        while (true)
        {
            if (node != null)
            {
                Traverse(node.left);
                Console.WriteLine(node.data);
                node = node.right;
                continue;
            }

            break;
        }
    }
}