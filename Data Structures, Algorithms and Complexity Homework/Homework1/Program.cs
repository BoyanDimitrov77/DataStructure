using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Homework1
    {

        // 1.What is the expected running time of the following C# code?
        //Assume the array's size is n.
        static long Compute(int[] arr)
        {
            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                    if (arr[start] < arr[end])
                    { start++; count++; }
                    else
                        end--;
            }
            return count;
        }

        /* Външния цикъл се изпълнява n наброй пъти,като на всяка една интерация вътрешния циклъл също се изпълнява n пъти-->
        О(N*N)   */

        //2.What is the expected running time of the following C# code?
        //Assume the input matrix has size of n * m.



        static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
                if (matrix[row, 0] % 2 == 0)
                    for (int col = 0; col < matrix.GetLength(1); col++)
                        if (matrix[row, col] > 0)
                            count++;
            return count;
        }

        /*Сложността на алгоритъма се определя в нашия случай от вложените цикли.Първият for-цикъл ще се изпълнява толкова
        наброй пъти колкото е големината на матрицата.Втория цикъл ще се изпълнява при някакво условие,което ще представлява 
        константна величина.От тука следва ,че при изпълняването на условито ще имаме n*m наброй операции-->О(n*m)
        */

        //3.What is the expected running time of the following C# code?
        //Assume the input matrix has size of n * m.


     static  long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
                sum += matrix[row, col];
            if (row + 1 < matrix.GetLength(1))
                sum += CalcSum(matrix, row + 1);
            return sum;
        }

        /*  Сложността на рекурсивната функция е O(n*m) обаче поради това n=m-->O(n^2) */
        static void Main(string[] args)
        {

            

        }
    }
}
