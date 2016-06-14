using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortIntegersList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = new List<int>();


            while (true)
            {

                string input = Console.ReadLine();
                if (input != "")
                {
                    int number = int.Parse(input);
                    if (number > 0)
                    {
                        sequenceOfNumbers.Add(number);
                    }


                }
                else
                {
                    break;
                }

            }

            DateTime start = DateTime.Now;

            sequenceOfNumbers.Sort();

            Console.WriteLine("Sorted Num");
            foreach (int num in sequenceOfNumbers)
            {
                Console.WriteLine("{0}",num);
            }

            DateTime end = DateTime.Now;
            Console.WriteLine(end-start);
        }
    }
}
