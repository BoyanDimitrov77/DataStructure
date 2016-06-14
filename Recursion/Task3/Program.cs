using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static int[] arr;
        static void Main(string[] args)
        {
            int number = 2;

            arr = new int[number];
            GenComb1(0, 1, 4);


        }

        private static void GenComb1(int index, int start, int end)
        {
            if (index == arr.Length)
            {
                Console.WriteLine("({0})", String.Join(" , ", arr));
                return;
            }


            for (int i = start; i <= end; i++)
            {
                arr[index] = i;
                GenComb1(index + 1, i+1, end);
            }
        }
    }
}
