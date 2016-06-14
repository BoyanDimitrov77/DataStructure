using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class CountNumbersOccureInArray
    {
        static void Main(string[] args)
        {
            double[] array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double,int> dictionary = new Dictionary<double, int>();

            foreach (var item in array)
            {
                int count = 1;
                if (dictionary.ContainsKey(item))
                {
                    count = dictionary[item] + 1;
                    dictionary[item] = count;
                }
                else
                {
                    dictionary.Add(item, count);
                }

                
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine("{0}------>{0}times",pair.Key,pair.Value);
            }




        }
    }
}
