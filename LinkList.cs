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
        public T? Value { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    public interface IIterator<T>
    {
        /// <summary>
        /// Iterate to the next value and return it.
        /// </summary>
        /// <returns></returns>
        public T? NextValue();

        /// <summary>
        /// Does the list have another value?
        /// </summary>
        /// <returns></returns>
        public bool HasNext();
    }

    public class Iterator<T> : IIterator<T>
    {
        BenjiLinkedList<T> List { get; set; }
        public int Count { get; private set; }
        internal Node<T>? CurrentNode { get; set; }
        public T? GetCurrentValue
        {
            get
            {
                if (CurrentNode == null)
                {
                    //TODO: Change it from returning a possible value to null or something similar.
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

        public Iterator(BenjiLinkedList<T> list)
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

    //Ran out of time to start creating proper stacks and queues rather than a multi-function class.
    public interface ILinkedListImp
    {

    }

    public class BenjiLinkedList<T>
    {
        internal Node<T>? FirstNode { get; set; }

        //Add a node to the front of list.
        public void AddFirst(T data)
        {
            Node<T>? oldFirst = FirstNode;
            FirstNode = new Node<T>(data) {Next = oldFirst };
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

        /// <summary>
        /// Returns an array of the linked list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T[]? GetArray()
        {
            //TODO: Replace this dumb solution.
            T[] arr = new T[1];
            if (FirstNode == null)
            {
                return null;
            }
            Iterator<T> it = new Iterator<T>(this);
            arr[0] = it.CurrentNode.Value;
            for (uint i = 1; it.HasNext(); i++)
            {
                T[] arr2 = new T[1 + i];
                for (uint j = 0; j < arr.Length; j++)
                {
                    arr2[j] = arr[j];
                }
                arr = arr2;
                arr[i] = it.NextValue();
            }
            return arr;
        }
    }
}
