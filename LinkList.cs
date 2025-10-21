using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_405_Code_Examples_and_Portfolio_Start
{
    internal class Node<T>
    {
        public T? Value { get; set; }
        public Node<T>? Next { get; set; }
    }

    public interface IIterator<T>
    {
        //
        public T Next();
        public bool HasNext();
    }

    public class Iterator<T> : IIterator<T>
    {
        LinkedList<T> List { get; set; }
        public int Count { get; set; }
        private Node<T> CurrentNode { get; set; }

        public Iterator(LinkedList<T> list)
        {
            List = list;
            Count = 0;
            CurrentNode = List.FirstNode;
        }

        public bool HasNext()
        {
            if (CurrentNode.Next != null) 
                return true;
            return false;
        }

        public T? Next()
        {
            CurrentNode = CurrentNode.Next;
            Count++;
            return CurrentNode.Value;
        }
    }

    public class LinkedList<T>
    {
        internal Node<T>? FirstNode { get; set; }
        
        //Add a node to the front of list.
        public void AddFirst(T data)
        {
            FirstNode = new Node<T> { Value = data, Next = FirstNode };
        }

        //Remove node at the front of the list.
        public void RemoveFirst()
        {
            FirstNode = FirstNode.Next;
        }
        
        public void AddLast(T data)
        {
            LastNode.Next = new Node<T> { Value = data, Next = null };
            LastNode = LastNode.Next;
        }

        public void RemoveLast()
        {

        }

        //Finds Node At Element.
        public T ElementAt(int index)
        {
            for(int i = 0; i <= index; i++)
            {

            }
        }
    }
}
