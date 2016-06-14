using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class SequenceOfPositiveNumber

    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = new List<int>();
       
           
            while(true) {

                string input = Console.ReadLine();
                if (input!="")
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
            int sum = 0;
            foreach (int num in sequenceOfNumbers)
            {
                sum = sum + num;
            }

            double average = (sum*1.0 / sequenceOfNumbers.Count);
            Console.WriteLine("Sum is:{0}",sum);
            Console.WriteLine("Average sum is: {0}", average);

        }
    }
}
