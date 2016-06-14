using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvlTrees;
namespace Trees.Test
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var tree = new AvlTrees.BinarySearchTrees<int>();

            var items = new int[] { 1, 67, 90, -123123, 4576567, 5, 7, 10 };

            foreach (var item in items)
            {
                tree.Add(item);
            }


            
           // tree.Remove(90);
            Console.WriteLine(tree.Size);
            foreach (var item in tree) 
            {
                Console.WriteLine("item {0}",item);
            }
        }
    }
}
