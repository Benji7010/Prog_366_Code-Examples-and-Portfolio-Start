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

        public Iterator(LinkedList<T> list)
        {
            List = list;
        }
        
        public bool HasNext()
        {
            throw new NotImplementedException();
        }

        public T Next()
        {
            
        }
    }

    public class LinkedList<T>
    {
        Node<T>? FirstNode { get; set; }

        //Add a node to the front of list.
        public void Shove(T data)
        {
            FirstNode = new Node<T> { Value = data, Next = FirstNode };
        }

        public T ElementAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
