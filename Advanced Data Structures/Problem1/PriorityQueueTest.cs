using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem1;
namespace Problem1
{
    class PriorityQueueTest
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(7);
            queue.Enqueue(30);
            queue.Enqueue(70);
            queue.Enqueue(1);
            queue.Enqueue(9);

            int max=queue.Dequeue();

            Console.WriteLine("{0}",max);

        }



    }
}
