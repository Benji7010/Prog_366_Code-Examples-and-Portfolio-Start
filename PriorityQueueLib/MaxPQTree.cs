using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueLib
{
    internal class PQTreeNode<T>(int key, T value)
    {
        public PQTreeNode<T>? Left 
        {
            get
            {
                return Left;
            }
            set
            {
                Left = value;
                value.Parent = this;
            }
        }
        public PQTreeNode<T>? Right
        {
            get
            {
                return Right;
            }
            set
            {
                Right = value;
                value.Parent = this;
            }
        }
        public PQTreeNode<T>? Parent { get; set; }
        public readonly int key = key;
        public readonly T value = value;
    }

    public class MaxPQTree<T> : IPriorityQueue<T>
    {
        private PQTreeNode<T> parent;
        
        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(int priority, T element)
        {
            if (parent == null)
            {
                parent = new PQTreeNode<T>(priority, element);
                return;
            }

            PQTreeNode<T> current = parent;

            while (true)
            {
                if(current.Left == null)
                {
                    current.Left = new PQTreeNode<T>(priority, element);
                    break;
                }
                if(current.Right == null)
                {
                    current.Right = new PQTreeNode<T>(priority, element);
                    break;
                }
                if(current.Left.key >)
            }
        }

        public void Sink()
        {
            throw new NotImplementedException();
        }

        public void Swim(int index)
        {
            throw new NotImplementedException();
        }
    }


}
