using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Problem1
{
    public class PriorityQueue<T> where T :IComparable<T>
    {
        private OrderedBag<T> queue;

        public PriorityQueue()
        {
            this.queue = new OrderedBag<T>();
        }

        public  int Count
        {
            get
            {
                return this.queue.Count;
            }
        }
            

        public void Clear()
        {
            this.queue.Clear();
        }

        public void Enqueue(T value)
        {
            this.queue.Add(value);
        }

        public T Dequeue()
        {
            return this.queue.RemoveLast();

        }




    }
}
