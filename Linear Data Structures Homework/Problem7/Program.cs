using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 4, 6, 8, 10, 11, 12, 13, 14, 15, 11, 12, 13, 14, 15, 11, 12, 13, 14, 15, 21, 21, 21, 21, 21, 21, 21, 21, 21,88,88,88 };
            int maxElemen = inputList.Max() + 1;
            int[] array = new int[maxElemen]; 

            foreach (int num in inputList)
            {
                array[num]++;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    Console.WriteLine("{0}--->{1} times", i, array[i]);
                }

            }  

                }

              


            }

        }
    

