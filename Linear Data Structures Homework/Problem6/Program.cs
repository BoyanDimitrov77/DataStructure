using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> newList = RevemoveOddNumOccure(list);
            foreach (int item in newList)
            {
                Console.WriteLine(item);
            }

        }

        static List<int>RevemoveOddNumOccure(List<int> list)
        {
            int index = 0;
            while (index < list.Count)
            {
                int counter = 0;
                int currentIndex = list[0];

                for (int i = 0; i < list.Count; i++)
                {
                    if (currentIndex == list[i])
                    {
                        counter++;
                    } 
                }
                if (counter % 2 != 0)
                {
                    list.RemoveAll(x => x == currentIndex);

                }
                else
                {
                    index++;
                }
               
            }


            return list;
        }
    }
}
