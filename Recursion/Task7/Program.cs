using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
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
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
          };



            Labyrinth labyrinth = new Labyrinth(matix);


            labyrinth.findAllPath(0, 0,'S');
        }

        public class DirectionVertor
        {
            public  int Row { get; set; }
            public int Column { get; set; }
            public char Sign { get; set; }

            public DirectionVertor(int row,int column,char sign)
            {
                this.Row = row;
                this.Column = column;
                this.Sign = sign;

            }
        }


        public class Labyrinth
        {
            private const char UNPASSABLE = '*';
            private char[,] matrix;
            private DirectionVertor[] vectors;
            public List<char> path = new List<char>();


            public Labyrinth(char[,] matrix)
            {
                this.matrix = matrix;
                this.vectors = GenerateVec(matrix);
            }

            public DirectionVertor[] GenerateVec(char[,] matrix)
            {

                return new DirectionVertor[] {
                    new DirectionVertor(-1,0,'U'),
                    new DirectionVertor(0,1,'R'),
                    new DirectionVertor(1,0,'D'),
                    new DirectionVertor(0,-1,'L')


                };


            }

            public void findAllPath(int row, int column,char dir)
            {

                if (row < 0 || row >= matrix.GetLength(0) ||
                   column < 0 || column>=matrix.GetLongLength(1))
                {
                    return;
           
                }

                if (this.matrix[row,column] == UNPASSABLE || this.matrix[row, column]== 'x')
                {
                    return;

                }

                if (this.matrix[row, column] == 'e')
                {
                    printPath();
                    return;
                }

                this.path.Add(dir);
                MarkCurrent(row, column);

                //findAllPath(row -1, column,'U');//up
                //findAllPath(row, column + 1,'R');//right
                //findAllPath(row + 1, column,'D');//down
                //findAllPath(row, column - 1,'L');//left

                for(int i = 0; i < vectors.Length; i++)
                {
                    findAllPath(row + vectors[i].Row, column + vectors[i].Column, vectors[i].Sign);
                }

                this.path.RemoveAt(this.path.Count - 1);
                UnMarkCurrent(row, column);

            }

            private void printPath()
            {

                Console.WriteLine(String.Join("->",this.path));

                for (int row = 0; row < this.matrix.GetLongLength(0); row++)
                {
                    for (int colum = 0; colum < this.matrix.GetLongLength(1); colum++)
                    {
                        Console.Write("{0} |", this.matrix[row,colum]);


                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
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
