using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        public static int[] arr;
        public static bool[] used = new bool[3];
        static void Main(string[] args)
        {

            int number = 3;
            arr = new int[number];

            Permutation(0);


        }

        private static void Permutation(int index)
        {

            if (index ==arr.Length)
            {
                Console.WriteLine(String.Join("," ,arr));
                return;
            }

           
            for(int i = 0; i <3; i++)
            {
                if (used[i])
                {
                    continue;
                }

                used[i] = true;
                arr[index] = i+1;
                Permutation(index + 1);

                used[i] = false;
            }


        }
    }
}
