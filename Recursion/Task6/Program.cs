using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {

        public static string[] inputArr = { "test", "rock", "fun" };
        public static string[] arr;
       

        static void Main(string[] args)
        {

            int number = 2;
            arr = new string [number];

            Recursion(0,0);


        }

        private static void Recursion(int index,int start)
        {
            if (index == arr.Length)
            {
                Console.WriteLine("({0})",String.Join(", ",arr));
                return;
            }




            for (int i = start; i < inputArr.Length; i++, start++)
            {


                arr[index] = inputArr[i];
                Recursion(index + 1, start + 1);

            }   

        }
    }
}
