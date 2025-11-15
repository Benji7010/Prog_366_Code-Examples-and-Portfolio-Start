using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PriorityQueueLib
{
    internal interface IPriorityQueue<T>
    {
        public void Enqueue(int priority, T element);
        public T Dequeue();
        public void Swim(int index);
        public void Sink();
    }
}
