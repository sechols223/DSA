namespace DSA.Trees;

public class TreeNode
{
    public TreeNode? right;
    public TreeNode? left;
    public int data;

    public TreeNode(int data)
    {
        this.data = data;
        this.left = null;
        this.right = null;
    }
}