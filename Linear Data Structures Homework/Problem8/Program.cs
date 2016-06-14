using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> inputList = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            int minElement = inputList.Min();
            int maxElement = inputList.Max();
            if (minElement >= 0)
            {
                minElement = 0;
            }
            int size = Math.Abs(minElement) + Math.Abs(maxElement) + 1;
            int[] arrayOfOccurrence = new int[size];
            foreach (int element in inputList)
            {
                arrayOfOccurrence[element + Math.Abs(minElement)]++;
            }
            int majorant = inputList.Count / 2 + 1;
            for (int i = 0; i < arrayOfOccurrence.Length; i++)
            {
                if (arrayOfOccurrence[i] == majorant)
                {
                    Console.WriteLine("The majorant is: {0}", i - Math.Abs(minElement));
                    break;
                }
                
                
            }
        }
    }
}
