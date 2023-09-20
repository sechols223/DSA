using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Queues;
public class Queue<T>
{
    private int front;
    private int back;
    private T[] queue;

    public Queue(int height) 
    { 
        queue = new T[height];
        front = 0;
        back = -1;

    }

    public void Add(T n)
    {
        back += 1;
        queue[back] = n;
    }

    public T Pop()
    {
        T value = queue[front];
        front += 1;

        return value;
    }

}
