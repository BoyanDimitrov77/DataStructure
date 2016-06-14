using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class ExtractWordsWithOddOccurrences
    {
        static void Main(string[] args)
        {

            string[] words = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL"};
            Dictionary<string, int> oddWords = new Dictionary<string, int>();
            foreach (var item in words)
            {
                int count = 1;
                if (oddWords.ContainsKey(item))
                {
                    count = oddWords[item] + 1;
                    oddWords[item] = count;
                }
                else
                {
                    oddWords.Add(item, count);
                }
            }
            List<string> list = new List<string>();
            foreach (var pair in oddWords)
            {
                if (pair.Value % 2 == 1)
                {
                    list.Add(pair.Key);

                }

            }


            foreach (var item in oddWords)
            {
                Console.Write(" {0} ,",item.Key);
            }
            Console.Write("------>");

            foreach (var item in list)
            {
                Console.Write("{0},",item);
            }
            Console.WriteLine();
        }
    }
}
