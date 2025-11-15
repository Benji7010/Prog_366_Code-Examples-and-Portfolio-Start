using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueLib
{
    internal class PQNode<T>
    {
        public readonly int key;
        public readonly T value;

        public PQNode(int key, T value)
        {
            key = this.key;
            this.value = value;
        }
    }

    internal class MaxPQArray<T> : IPriorityQueue<T>
    {
        private PQNode<T>[] tree;
        private int next;

        public MaxPQArray()
        {
            tree = new PQNode<T>[2];
            next = 1;
        }

        public void Enqueue(int priority, T element)
        {
            if (next >= tree.Length)
            {
                Resize(tree.Length * 2);
            }

            tree[next] = new PQNode<T>(priority, element);
            Swim(next);

            next++;
        }

        public T Dequeue()
        {
            PQNode<T> max = tree[1];
            next--;

            tree[1] = tree[next];
            tree[next] = null;

            if (next <= tree.Length/4)
            {
                Resize(tree.Length / 2);
            }

            return max.value;
        }

        public void Swim(int index)
        {
            if (index == 1) return;

            int parIDX = GetParentNodeForIndex(index);

            if (parIDX < tree[index].key)
            {
                PQNode<T> temp = tree[index];
                tree[index] = tree[parIDX];
                tree[parIDX] = temp;
            }
        }

        private int GetParentNodeForIndex(int i)
        {
            if (i == 0) return -1;
            if (i %  2 == 0)
                return tree[i / 2].key;
            else
                return tree[i / 2 - 1].key;
        }

        private int GetLeftChildIndexForParentIndex(int i)
        {
            if (i == 0) return -1;
            return tree[i * 2].key;
        }

        private int GetRightChildIndexForParentIndex(int i)
        {
            return GetLeftChildIndexForParentIndex(i) + 1;
        }

        public void Sink()
        {
            if(tree.Length == 0) return;

            PQNode<T> temp;

            for (int i = 0; i < tree.Length; i++)
            {
                if (tree[GetLeftChildIndexForParentIndex(i)].key > tree[GetRightChildIndexForParentIndex(i)].key)
                {
                    temp = tree[i];
                    tree[i] = tree[i * 2];
                    tree[i * 2] = temp;
                }
            }
        }

        private void Resize(int c)
        {
            PQNode<T>[] newArray = new PQNode<T>[c];

            for (int i = 1; i < tree.Length; i++)
            {
                if (tree[i] == null) break;

                newArray[i] = tree[i];
            }

            tree = newArray;
        }
    }
}
