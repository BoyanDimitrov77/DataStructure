using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 5, 5 };
            //int[] arr1 = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

            PermutationWihtRepetion per = new PermutationWihtRepetion(arr);
            per.Permutation(arr.Length);
            per.pirntPermutation();


        }

        public class PermutationWihtRepetion
        {

            private int[] arr;
            public List<string> listOfPermutation = new List<string>();
            public PermutationWihtRepetion(int[] arr)
            
            {
                this.arr = arr;
            }
                       
            public void Permutation(int size)
            {

                if (size == 0)
                {
                    listOfPermutation.Add(string.Join(" ", arr));
                    return;
                }


                Permutation(size - 1);
                for (int i = 0; i < size - 1; i++)
                {
                    if (this.arr[i] != this.arr[size - 1])
                    {
                        swap( ref this.arr[i], ref this.arr[size - 1]);
                       Permutation(size-1);
                        swap( ref this.arr[i], ref  this.arr[size - 1]);


                    }

                    

                }


            }

            public  void swap<T>(ref T a, ref T b)
            {
                T swap = a;
                a = b;
                b = swap;
            }

            public void pirntPermutation()
            {
                foreach (var permutation in listOfPermutation)
                {
                    Console.WriteLine(permutation);
                }

                Console.WriteLine(listOfPermutation.Count);
            }
        }
    }
}
