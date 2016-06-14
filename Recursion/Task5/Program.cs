using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        public static string[] inputArr = { "hi", "a", "b" };
        public static string[] arr;
        
        static void Main(string[] args)
        {
            int number = 2;
            arr = new string[number];

            variations(0);
        }

        private static void variations(int index)
        {

            if (index == arr.Length)
            {
                Console.WriteLine("({0})",String.Join(", ",arr));
                return;
            }

            for (int i = 0; i < inputArr.Length; i++)
            {
                arr[index] = inputArr[i];
                variations(index + 1);

            }

        }
    }
}
