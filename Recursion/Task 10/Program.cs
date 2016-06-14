using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matix =
          {
            {' ', ' ', ' ', 'x', ' ', ' ', ' '},
            {'x', 'x', ' ', 'x', ' ', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', 'x', 'x', 'x', 'x', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
          };



            Labyrinth labyrinth = new Labyrinth(matix);


            labyrinth.findAllPath(0, 0, 'S');
            labyrinth.printPath();
        }

        

        public class Labyrinth
        {
            private const char UNPASSABLE = '*';
            private char[,] matrix;
          
            private int countPassableCell=0;

            public Labyrinth(char[,] matrix)
            {
                this.matrix = matrix;
               
            }

            
            public void findAllPath(int row, int column, char dir)
            {

                if (row < 0 || row >= matrix.GetLength(0) ||
                   column < 0 || column >= matrix.GetLongLength(1))
                {
                    return;

                }

                if (this.matrix[row, column] == UNPASSABLE || this.matrix[row, column] == 'x')
                {
                    return;

                }

                if(matrix[row,column]==' ')
                {
                    MarkCurrent(row, column);
                    countPassableCell++;
                    findAllPath(row - 1, column, 'U');//up
                    findAllPath(row, column + 1, 'R');//right
                    findAllPath(row + 1, column, 'D');//down
                    findAllPath(row, column - 1, 'L');//left
                }
               


                

            }

            public void printPath()
            {

               

                for (int row = 0; row < this.matrix.GetLongLength(0); row++)
                {
                    for (int colum = 0; colum < this.matrix.GetLongLength(1); colum++)
                    {
                        Console.Write("{0} |", this.matrix[row, colum]);


                    }
                    Console.WriteLine();
                }


                Console.WriteLine("Passable cell {0}", countPassableCell);
            }

           
            private void MarkCurrent(int row, int column)
            {
                this.matrix[row, column] = UNPASSABLE;
            }
        }

    }
}
