using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    class Program
    {

       

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number:");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                string enteredNum = Console.ReadLine();
                int SNum = int.Parse(enteredNum);
                list.Add(SNum);
            }

            List<int> listWithoutNegativeNumber = RemoveNegativeNum(list);

            foreach (int num in listWithoutNegativeNumber) 
            {

                Console.WriteLine(num);
            }


        }

        static List<int> RemoveNegativeNum(List<int> list)
        {
            List<int> newList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    list.Remove(list[i]);
                }
                else
                {
                    newList.Add(list[i]);
                }
            }

            return newList;
        }

     
    }
}
