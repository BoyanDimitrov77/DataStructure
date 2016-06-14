using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {

        static List<int> FindSubsequence(List<int> num)
        {
            

            int currentNum = num[0];
            int counter = 1;
            int max = 1;
            int maxNum = num[0];

            for (int i = 0; i < num.Count; i++)
            {
                if (num[i] == currentNum)
                {
                    counter++;

                    if (counter > max)
                    {
                        max = counter;
                        maxNum = currentNum;

                    }

                }
                else
                {
                    currentNum = num[i];
                    counter = 1;
                }


            }

            List<int> list = new List<int>();

            for (int o = 0; o <max; o++)
            {

                list.Add(maxNum);
            }

            return list;


        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>(){1,2,3,4,7,7,7,7,7,6,};
            List<int>SequenceOfNumber= FindSubsequence(list);

            Console.Write("{");
            foreach (int  num in SequenceOfNumber)
            {
                Console.Write("{0}",num);
            }
            Console.WriteLine("}");
            Console.WriteLine();
        }
    }
}
