using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalEditDistance
{
    class MinimalEditDistance
    {
        private static double[,] table;

        private const double ReplaceALetterCosnt = 1;
        private const double DeleteAletterConst = 0.9;
        private const double AddALetterConst = 0.8;


        static void Main(string[] args)
        {
            var input = "developer";
            var output = "enveloped";

            table = new double[input.Length + 1, output.Length + 1];
            //fill first row
            for (int i = 1; i < table.GetLength(1); i++)
            {
                table[0, i] = table[0,i-1]+ DeleteAletterConst;
            }
            //fill first colum
            for (int j = 1; j < table.GetLength(0); j++)
            {
                table[j, 0] = table[j-1,0]+ DeleteAletterConst;
            }

            MinimalDinstance(input, output);

            PrintMinEditDistance();

           // printResult();
        }

        private static void PrintMinEditDistance()
        {
            Console.WriteLine("MinEditDistance is:");
            Console.WriteLine(table[table.GetLength(0)-1,table.GetLength(1)-1]);
        }

        private static void MinimalDinstance(string input, string output)
        {

            for (int row = 1; row < table.GetLongLength(0); row++)
            {
                for (int column = 1; column < table.GetLongLength(1); column++)
                {
                    var replaceCost = table[row - 1, column - 1];
                    if (input[row - 1] != output[column - 1])
                    {
                        replaceCost += ReplaceALetterCosnt;
                    }
                    var addCosst = table[row, column-1] + AddALetterConst;
                    var deleteCosts = table[row - 1, column] + DeleteAletterConst;

                    var minDinstance = GetMin(replaceCost, addCosst, deleteCosts);

                    table[row, column]=minDinstance;

                }
            }

           


        }

        private static double GetMin(params double[] items)
        {
            return items.Min();
        }


        private static void printResult()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write("    " + table[i, j]);

                }
                Console.WriteLine();
            }
        }

    }
}
