using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class PriorityStack<T> where T : IComparable<T>
{
    private LinkedList<T> linkedList = new LinkedList<T>();


    public void Push(T item)
    {
        foreach (var comparableItem in linkedList)
        {
            if (linkedList.Count == 0)
            {
                linkedList.AddFirst(item);
                return;
            }
            if (item.CompareTo(comparableItem) > 0)
            {
                linkedList.AddBefore(linkedList.Find(comparableItem), item);
                return;
            }
            if (item.CompareTo(comparableItem) <= 0)
            {
                linkedList.AddAfter(linkedList.Find(comparableItem), item);
                return;
            }
        }

    }

    public T Pop()
    {
        if (linkedList.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        var item = linkedList.First.Value;
        linkedList.Remove(item);
        return item;
    }

    public int Count()
    {
        return linkedList.Count;
    }

    public bool IsEmpty()
    {
        if (linkedList.Count == 0)
        {
            return true;
        }
        else return false;
    }
}


