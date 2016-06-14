using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matix =
          {
            { "1", "x", "2", "2", "2", "x" },
            { "x", "x", "x", "2", "4", "x" },
            { "4", "x", "1", "2", "x", "x" },
            { "4", "x", "1", "2", "x", "1" },
            { "4", "x", "1", "x", "x", "x" }

            //{'1', '7', '7', 'x', '8', '8', '0'},
            //{'x', 'x', '7', 'x', '8', 'x', '0'},
            //{'1', '7', '7', '7', '8', '0', '0'},
            //{'1', 'x', 'x', 'x', 'x', 'x', '0'},
            //{'1', '9', '9', '9', '8', '0', 'e'},
          };



            Labyrinth labyrinth = new Labyrinth(matix);


            int result =labyrinth.FindLargestAreanInMatrix();
            
           labyrinth.printPath();
        }

        


        public class Labyrinth
        {
            private const string UNPASSABLE = "*";
            private string[,] matrix;
           
            public List<char> path = new List<char>();


            public Labyrinth(string[,] matrix)
            {
                this.matrix = matrix;
                
            }

            public int FindLargestAreanInMatrix()
            {
                int maxCount = int.MinValue;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int colum = 0; colum < matrix.GetLength(0); colum++)
                    {
                        var currentCount = 0;

                        findArea(row, colum,  currentCount);


                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                        }
                    }
                }

                return maxCount;
            }

            

            public void findArea(int row, int column,  int currentLenght)
            {

                if (row < 0 || row >= matrix.GetLength(0) ||
                   column < 0 || column >= matrix.GetLongLength(1) || matrix[row,column]!="x")
                {
                    return;

                }
                currentLenght++;

             
                MarkCurrent(row, column);

                findArea(row - 1, column,   currentLenght);//up
                findArea(row, column + 1,   currentLenght);//right
                findArea(row + 1, column, currentLenght);//down
                findArea(row, column - 1, currentLenght);//left

               // UnMarkCurrent(row, column);

            }

            public void printPath()
            {

               

                for (int row = 0; row < this.matrix.GetLongLength(0); row++)
                {
                    for (int colum = 0; colum < this.matrix.GetLongLength(1); colum++)
                    {
                        Console.Write("{0} ", this.matrix[row, colum]);


                    }
                    Console.WriteLine();
                }

               
            }

            private void UnMarkCurrent(int row, int column)
            {
                this.matrix[row, column] = " ";
            }

            private void MarkCurrent(int row, int column)
            {
                this.matrix[row, column] = UNPASSABLE;
            }
        }

    }
}
