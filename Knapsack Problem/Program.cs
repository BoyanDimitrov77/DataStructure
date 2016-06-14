using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_Problem
{

    class Program
    {
        static List<Items> sortedItems;
        static void Main(string[] args)
        {
            int M = 10;//vmestimost na rancata
            List<Items> items = new List<Items>();
               
            items.Add(new Items("beer", 3, 2));
            items.Add(new Items("vodka", 8, 12));
            items.Add(new Items("cheese", 4, 5));
            items.Add(new Items("nuts", 1, 4));
            items.Add(new Items("ham", 2, 3));
            items.Add(new Items("whiskey", 8, 13));

            //items.Sort((x, y) => x.Cost.CompareTo(y.Cost));
           sortedItems = items.OrderBy(o => o.Weight).ToList();

            foreach (var item in sortedItems)
            {
                Console.WriteLine(item.Name +" "+item.Weight+" "+item.Cost);
            }

            var table = new int[sortedItems.Count+1, M + 1];

            for (int i = 0; i <=M; i++)
            {
                table[0, i] = 0;
            }

            var resultTable=Knapsack(table,M,sortedItems);

            printResult(resultTable);
            var maxElementIndex = FindMaxElementIndexColumnInLastRow(table);
            var maxValueOfElementFromTable = table[sortedItems.Count, maxElementIndex];

            Console.WriteLine("Optimal solution");

            PrintProduct(maxElementIndex, maxValueOfElementFromTable,table);

        }

        private static void PrintProduct(int maxElementIndex, int maxValueOfElementFromTable, int[,] table)
        {
            //printirame elementite koito sa s max cena i kg
            int currentRow = table.GetLength(0) - 1;
            int currentColumn = maxElementIndex;
            int currentValue = maxValueOfElementFromTable;
            int UpValue = 0;


            while(currentRow>0 && currentColumn > 0)
            {
                UpValue = table[currentRow - 1, currentColumn];

                if (UpValue != currentValue)
                {
                    Console.WriteLine(sortedItems[currentRow-1]);
                    currentColumn -= sortedItems[currentRow - 1].Weight;
                }

                currentValue = table[--currentRow, currentColumn];

            }



        }

        private static int  FindMaxElementIndexColumnInLastRow(int[,] table)
        {
            //vinagi posledniq element na reda e nai-golqm,vzimame negoviq indeks
            int maxValue = int.MinValue;
            int maxIndexOfvalue = 0;

           
                for (int j = 0; j < table.GetLength(1); j++)
                {
                var currentValue = table[table.GetLength(0) - 1, j];
                    if (currentValue > maxValue)
                    {
                    maxValue = currentValue;
                    maxIndexOfvalue = j;

                    }

                }
            return maxIndexOfvalue;
            
        }

       

        private static int[,] Knapsack(int[,] table, int m, List<Items> sortedItems)
        {

            for (int i = 1; i <table.GetLength(0); i++)
            {
                for (int j = 1; j <table.GetLength(1); j++)
                {

                    var item = sortedItems[i-1];
                    if (j < item.Weight)         //tuk proverqva dali tegloto ,koeto e nalichno moje da se pobere,ako da ->
                    {
                        table[i, j] = table[i - 1, j];
                    }
                    else    //ako ne -> izbira se maksimalnata  stoinost
                    {
                        table[i, j] = Math.Max((item.Cost + table[i - 1, j - item.Weight]), table[i - 1, j]);
                    }


                }
            }


            return table;
        }

        private static void printResult(int[,] resultTable)
        {
            for (int i = 0; i < resultTable.GetLength(0); i++)
            {
                for (int j = 0; j < resultTable.GetLength(1); j++)
                {
                    Console.Write(" " + resultTable[i, j]);

                }
                Console.WriteLine();
            }
        }



    }
}
