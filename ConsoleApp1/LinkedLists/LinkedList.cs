using DSA.Common;

using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace DSA.LinkedLists;
public class LinkedList<T>
{
    public class ListNode
    {
        public T? data;
        public ListNode? next;

        public ListNode(object? data)
        {
            this.data = (T?) data;
            next = null;
        }
    }

    private ListNode? head;
    private int count = 0;
    public int Count { get => count; }

    public void PrintList()
    {
        if (head != null)
        {
            ListNode? current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
    }

    public T? FindAt(int index)
    {
        if (head != null)
        {
            ListNode? current = head;
            int count = 0;
            while (current.next != null && count != index)
            {
                count += 1;
                current = current.next;
            }
            return current.data;
        } else
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public void Insert(T data)
    {
        ListNode newNode = MakeNode(data);
        if (head != null)
        {
            ListNode end = FindTail();
            end.next = newNode;
        } else
        {
            head = newNode;
        }
        this.count++;
    }
    public void InsertAfter(int index, T data)
    {
        ListNode newNode = MakeNode(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            ListNode current = head;
            int cnt = 0;

            while (current.next != null && count != index)
            {
                current = current.next;
                cnt++;
            }

            if (current == null)
            {
                throw new IndexOutOfRangeException("Index is beyond the end of the list.");
            }
            this.count++;
            newNode.next = current.next;
            current.next = newNode;
        }
    }
    public void InsertAfter(ListNode node, T data)
    {
        ListNode newNode = MakeNode(data);
        newNode.next = node.next;
        node.next = newNode;
        this.count++;

    }

    private void InsertBefore(ListNode node, T data)
    {
        ListNode newNode = MakeNode(data);
        newNode.next = node.next;
        node.next = newNode;
        this.count++;
    }

    public void InsertOrdered(T data)
    {
        ListNode newNode = MakeNode(data);
        Indexer indexer = new();
        if (head == null)
        {
            head = newNode;
            this.count++;
        } else
        {
            
            ListNode current = head;
            int val = indexer.GetStringValue(data!.ToString()!);

            ListNode? spot = FindSpot(data.ToString());
            int spotVal = indexer.GetStringValue(spot!.data!.ToString()!);
            int headVal = indexer.GetStringValue(head.data!.ToString()!);
            //If the spot is the front of the list then insert it into the front.
            if (spotVal == headVal)
            {
                if (headVal < val)
                {
                    InsertAfter(spot!, data);
                }
                else
                {
                    newNode.next = head;
                    head = newNode;
                    this.count++;
                }
            } else
            {
                InsertAfter(spot!, data);
            }
        }
    }

    public void Delete(ListNode node)
    {
        ListNode? next = node.next;
        node.next = next?.next;
        this.count--;
    }
    private ListNode MakeNode(T data)
    {
        return new ListNode(data);
    }
    private ListNode FindTail()
    {
        if (head == null)
        {
            return new ListNode(null);
        }

        ListNode current = head;
        while (current.next != null) 
        {
            current = current.next;
        }
        return current;
    }

    private ListNode? FindSpot(string data)
    {
        if (head != null)
        {
            Indexer indexer = new();

            ListNode? current = head;
            ListNode? prev = current;

            while (current != null && (indexer.GetStringValue(current.data.ToString()) < indexer.GetStringValue(data)
                                       || (indexer.GetStringValue(current.data.ToString()) == indexer.GetStringValue(data)
                                           && string.Compare(current.data.ToString(), data) < 0)))
            {
                prev = current;
                current = current.next;
            }

            return prev;
        }
        return null;
    }
   





}
