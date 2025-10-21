using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prog_405_Code_Examples_and_Portfolio_Start
{
    internal class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    public interface IIterator<T>
    {
        public T? NextValue();

        public bool HasNext();
    }

    public class Iterator<T> : IIterator<T>
    {
        LinkedList<T> List { get; set; }
        public int Count { get; private set; }
        internal Node<T>? CurrentNode { get; set; }
        public T? GetCurrentValue
        {
            get
            {
                if (CurrentNode == null)
                {
                    return default(T?);
                }
                return CurrentNode.Value;
            }
        }
        public T SetCurrentValue {
            set
            {
                if (CurrentNode != null)
                {
                    CurrentNode.Value = value;
                }
            }
        }
        
        //Iterate to the next value and return it.
        public T? NextValue()
        {
            if (CurrentNode != null)
            {
                if (HasNext())
                {
                    CurrentNode = CurrentNode.Next;
                    Count++;
                    if (CurrentNode != null)
                        return CurrentNode.Value;
                }
            }
            return default(T);
        }

        public Iterator(LinkedList<T> list)
        {
            List = list;
            Count = 0;
            CurrentNode = List.FirstNode;
        }

        //Is there another node after the current?
        public bool HasNext()
        {
            if (CurrentNode != null && CurrentNode.Next != null) 
                return true;
            return false;
        }
    }

    public class LinkedList<T>
    {
        internal Node<T>? FirstNode { get; set; }

        //Add a node to the front of list.
        public void AddFirst(T data)
        {
            FirstNode = new Node<T>(data) {Next = FirstNode };
        }

        //Remove node at the front of the list.
        public void RemoveFirst()
        {
            if (FirstNode != null)  
                FirstNode = FirstNode.Next;
        }
        
        //Add node to the end of the list.
        public void AddLast(T data)
        {
            if(FirstNode == null)
            {
                AddFirst(data);
                return;
            }
            Iterator<T> iterator = new Iterator<T>(this);
            while (iterator.CurrentNode.Next != null)
            {
                iterator.NextValue();
            }
            Node<T>? lastNode = iterator.CurrentNode;
            if (lastNode == null)
            {
                lastNode = new Node<T>(data);
            }
            else
            {
                lastNode.Next = new Node<T>(data);
            }
        }

        //Remove last node from the list.
        public void RemoveLast()
        {
            if (FirstNode == null)
            {
                RemoveFirst();
                return;
            }
            Iterator<T> iterator = new Iterator<T>(this);
            Node<T>? previousNode = null;
            while (iterator.CurrentNode.Next != null)
            {
                previousNode = iterator.CurrentNode;
                iterator.NextValue();
            }
            iterator.CurrentNode = previousNode;
        }
    }
}
