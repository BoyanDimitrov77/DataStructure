using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 2;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            

            for (int i = 0; i < 50; i++)
            {
                queue.Enqueue(queue.ElementAt(i) + 1);
                queue.Enqueue(2 * queue.ElementAt(i) + 1);
                queue.Enqueue(queue.ElementAt(i) + 2);
            }

            foreach (int num in queue)
            {
                Console.Write("{0},",num);
            }

        }
    }
}
