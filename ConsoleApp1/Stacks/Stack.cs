namespace DSA.Stacks;
public class CustomStack<T>
{
    private int top = -1;
    private T[] stack;

    public CustomStack(int height)
    {
        stack = new T[height];
    }

    public void Push(T n)
    {
        top += 1;
        stack[top] = n;
    }

    public T Pop()
    {
        T value = stack[top];
        top--;

        return value;
    }
    public T Peek()
    {
        return stack[top];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }
}
