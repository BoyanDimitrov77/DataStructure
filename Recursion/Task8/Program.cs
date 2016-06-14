using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 100;
            char [,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colum = 0; colum < matrix.GetLength(1); colum++)
                {
                    matrix[row, colum] = ' ';

                }
            }

            Console.WriteLine("Enter start point row");
            string input = Console.ReadLine();
            int startPointRow = int.Parse(input);

            Console.WriteLine("Enter start point colum");
            input = Console.ReadLine();
            int startPointColum = int.Parse(input);

            Console.WriteLine("Enter end point row");
            input = Console.ReadLine();
            int endPointRow = int.Parse(input);

            Console.WriteLine("Enter end point colum");
            input = Console.ReadLine();
            int endPointColum = int.Parse(input);

            matrix[endPointRow, endPointColum] = 'e';




            //  char[,] matix =
            //{
            //  {' ', ' ', ' ', 'x', ' ', ' ', ' '},
            //  {'x', 'x', ' ', 'x', ' ', 'x', ' '},
            //  {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            //  {' ', 'x', 'x', 'x', 'x', 'x', ' '},
            //  {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
            //};



            Labyrinth labyrinth = new Labyrinth(matrix);


            labyrinth.findAllPath(startPointRow, startPointColum, 'S');
        }

       


        public class Labyrinth
        {
            private const char UNPASSABLE = '*';
            private char[,] matrix;
            private bool found = false;
         
            public List<char> path = new List<char>();


            public Labyrinth(char[,] matrix)
            {
                this.matrix = matrix;
               
            }

          

            public void findAllPath(int row, int column,char dir)
            {

                if (row < 0 || row >= matrix.GetLength(0) ||
                   column < 0 || column >= matrix.GetLongLength(1))
                {
                    return;

                }

              

                if (this.matrix[row, column] == 'e')
                {
                    printPath();
                    Console.WriteLine("PathFound");
                    Console.WriteLine();
                    found = true;
                
                    return;
                }
                if (found == true)
                {
                    return;
                }
                else
                {

                    if(matrix[row,column]==' ')
                    {
                        MarkCurrent(row, column);

                        findAllPath(row - 1, column, 'U');//up
                        findAllPath(row, column + 1, 'R');//right
                        findAllPath(row + 1, column, 'D');//down
                        findAllPath(row, column - 1, 'L');//left



                        UnMarkCurrent(row, column);

                    }
                    
                }

                
                

            }

            private void printPath()
            {

               
                for (int row = 0; row < this.matrix.GetLongLength(0); row++)
                {
                    for (int colum = 0; colum < this.matrix.GetLongLength(1); colum++)
                    {
                        if (matrix[row, colum] == ' ')
                        {

                            Console.Write("o", matrix[row, colum]);
                        }
                        else
                        {
                            Console.Write("{0} ", this.matrix[row, colum]);
                        }
                        

                        


                    }
                    Console.WriteLine();
                }

             
            }

            private void UnMarkCurrent(int row, int column)
            {
                this.matrix[row, column] = ' ';
            }

            private void MarkCurrent(int row, int column)
            {
                this.matrix[row, column] = UNPASSABLE;
            }
        }

    }
}
