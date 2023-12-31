﻿using DSA.Common;

namespace DSA.LinkedLists;
public class LinkedList<T>
{
    public class ListNode
    {
        public T? data;
        public ListNode? next;

        public ListNode(T? data)
        {
            this.data =  data;
            next = null;
        }
    }

    private ListNode? head;
    private int count;

    private LinkedList<T>[] listIndex = new LinkedList<T>[26];
    public int Length { get => count; }

    public void PrintList()
    {
        if (head != null)
        {
            int cnt = 0;
            ListNode? current = head;
            while (current != null)
            {
                cnt++;
                if (cnt % 5 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{current.data}, ");
                current = current.next;
            }
        }
    }

    public T? FindAt(int index)
    {
        if (head != null)
        {
            ListNode? current = head;
            int cnt = 0;
            while (current.next != null && cnt != index)
            {
                cnt++;
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
            ListNode end = FindTail()!;
            end.next = newNode;
        } 
        else
        {
            head = newNode;
        }
        count++;
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
            while (current.next != null && cnt != index)
            {
                current = current.next;
                cnt++;
            }

            if (current == null)
            {
                throw new IndexOutOfRangeException("Index is beyond the end of the list.");
            }
            
            count++;
            newNode.next = current.next;
            current.next = newNode;
        }
    }
    private void InsertAfter(ListNode node, T data)
    {
        ListNode newNode = MakeNode(data);
        newNode.next = node.next;
        node.next = newNode;
        count++;
    }
    
    public void InsertOrdered(T data)
    {
        ListNode newNode = MakeNode(data);
       
        if (head == null)
        {
            head = newNode;
            count++;
        } 
        else
        {
            int val = Indexer.GetStringValue(data!.ToString()!);

            ListNode? spot = FindSpot(data.ToString()!);
            
            int spotVal = Indexer.GetStringValue(spot!.data!.ToString()!);
            int headVal = Indexer.GetStringValue(head.data!.ToString()!);
            
            if (spotVal == headVal)
            {
                if (headVal < val)
                {
                    InsertAfter(spot, data);
                }
                else
                {
                    newNode.next = head;
                    head = newNode;
                    count++;
                }
            } 
            else
            {
                InsertAfter(spot, data);
            }
        }
        BuildIndex();
    }
    
    private void BuildIndex()
    {
        listIndex = new LinkedList<T>[26];
        if (head != null)
        {
            ListNode? current = head;
            
            while (current != null)
            {
                char c = current.data!.ToString()![0];
                int value = Indexer.GetCharValue(c);

                if (listIndex[value] == null)
                {
                    listIndex[value] = new LinkedList<T>();
                }
                
                listIndex[value].Insert(current.data);
                current = current.next;
            }
        }
    }

    public void PrintSection(char section)
    {
        section = char.ToLower(section);
        int value = Indexer.GetCharValue(section);

        if (listIndex[value] == null)
        {
            Console.WriteLine("NULL");
        }
        else
        {
            LinkedList<T> list = listIndex[value];
            ListNode? current = list.head;

            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
        
    }

    public int GetSectionLength(char section)
    {
        section = char.ToLower(section);
        int value = Indexer.GetCharValue(section);
        int cnt = 0;
        if (listIndex[value] != null)
        {
            LinkedList<T> list = listIndex[value];
            ListNode? current = list.head;

            while (current != null)
            {
                current = current.next;
                cnt++;
            }
        }

        return cnt;
    }
    
    public void Delete(ListNode node)
    {
        ListNode? next = node.next;
        node.next = next?.next;
        count--;
    }
    private ListNode MakeNode(T data)
    {
        return new ListNode(data);
    }
    private ListNode? FindTail()
    {
        if (head == null)
        {
            return null;
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
            ListNode? current = head;
            ListNode? prev = current;

            while (current != null && Indexer.GetStringValue(current.data!.ToString()!) <= Indexer.GetStringValue(data))
            {
                prev = current;
                current = current.next;
            }

            return prev;
        }
        return null;
    }
}
