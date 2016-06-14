using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumberStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number:");
            string n = Console.ReadLine();
            int countNum = int.Parse(n);

            Console.WriteLine("Please enter {0} numbers", countNum);
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < countNum; ++i)
            {
                string input = Console.ReadLine();
                int addNum = int.Parse(input);
                stack.Push(addNum);

            }

            Console.WriteLine("ReverseNum:");
            foreach (int num in stack)
            {
                Console.WriteLine(num);
            }

        }
    }
}
