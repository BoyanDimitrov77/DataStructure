using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10
{
    class Program
    {
        

        static LinkedList<int> FindMINOperations(Queue<LinkedList<int>> queueList, int M)
        {
            while (true)
            {
                LinkedList<int> currentList = queueList.Dequeue();
                LinkedListNode<int> currentLastElement = currentList.Last;

                int firstNextValue = currentLastElement.Value + 1;
                LinkedList<int> firstNextList = new LinkedList<int>(currentList);
                firstNextList.AddLast(firstNextValue);
                if (firstNextValue < M)
                {
                    queueList.Enqueue(firstNextList);
                }
                else if (firstNextValue == M)
                {
                    queueList.Enqueue(firstNextList);
                    return firstNextList;
                }
                int secondNextValue = currentLastElement.Value + 2;
                LinkedList<int> secondNextList = new LinkedList<int>(currentList);
                secondNextList.AddLast(secondNextValue);
                if (secondNextValue < M)
                {
                    queueList.Enqueue(secondNextList);
                }
                else if (secondNextValue == M)
                {
                    queueList.Enqueue(secondNextList);
                    return secondNextList;
                }
                int thirdNextValue = currentLastElement.Value * 2;
                LinkedList<int> thirdNextList = new LinkedList<int>(currentList);
                thirdNextList.AddLast(thirdNextValue);
                if (thirdNextValue < M)
                {
                    queueList.Enqueue(thirdNextList);
                }
                else if (thirdNextValue == M)
                {
                    queueList.Enqueue(thirdNextList);
                    return thirdNextList;
                }
            }

        }
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            string inputLine = Console.ReadLine();
            int firstElement = int.Parse(inputLine);
            LinkedList<int> firstList = new LinkedList<int>();
            firstList.AddLast(firstElement);
            Queue<LinkedList<int>> solutions = new Queue<LinkedList<int>>();
            solutions.Enqueue(firstList);
            Console.Write("Enter M: ");
            inputLine = Console.ReadLine();
            int numberM = int.Parse(inputLine);
            LinkedList<int> result = FindMINOperations(solutions, numberM);
            Console.Write("Result: ");
            while (result.Count > 0)
            {
                LinkedListNode<int> temp = result.First;
                if (temp.Next != null)
                {
                    Console.Write("{0}->", temp.Value);
                    result.RemoveFirst();
                }
                else
                {
                    Console.WriteLine("{0}.", temp.Value);
                    result.RemoveFirst();
                }
            }
        }
    }
}
