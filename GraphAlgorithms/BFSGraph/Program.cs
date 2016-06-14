using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension;


namespace BFSGraph
{
    class Program
    {
        static string input = @"3 1
5 4
3 4
5 3
1 2
5 2
3 6";
        static void Main(string[] args)
        {
            int n = 6;
            int m = 7;

            List<int>[] vertices = new List<int>[n];

            input.Split('\n').ForEach(egeString =>
            {
                var parts = egeString.Split(' ');
                var v1 = int.Parse(parts[0]) - 1;
                var v2 = int.Parse(parts[1]) - 1;

                if (vertices[v1] == null)
                {
                    vertices[v1] = new List<int>();
                }

                if (vertices[v2] == null)
                {
                    vertices[v2] = new List<int>();
                }


                vertices[v1].Add(v2);
                vertices[v2].Add(v1);


            });

            BFS(vertices, 0);


        }

        class Node
        {
            public int Vertex { get; set; }
            public int Level { get; set; }
        }
        private static void BFS(List<int>[] vertices, int v)
        {
            Queue<Node> queue = new Queue<Node>();
            var path = new int[vertices.Length];
            queue.Enqueue(new Node
            {
                Vertex = v,
                 Level = 0
            });
            HashSet<int> visited = new HashSet<int>();

            visited.Add(v);
            path[v] = -1;

            while (queue.Count > 0)
            {

                var current = queue.Dequeue();
               // Console.WriteLine("{0}{1}",new string('-',current.Level),current.Vertex+1);

                if (vertices[current.Vertex] == null)
                {
                    continue;
                }

                foreach (var neighbour in vertices[current.Vertex])
                {

                    if (visited.Contains(neighbour))
                    {
                        continue;
                    }
                    path[neighbour] = current.Vertex;
                    queue.Enqueue(new Node
                    {
                        Vertex = neighbour,
                        Level = current.Level + 1
                    }
                    );
                    visited.Add(neighbour);
                }
            }

            for (int i = 0; i < path.Length; i++)
            {
                Console.WriteLine("{0}->{1}", i + 1, path[i]+1); ;
            }
        }
    }
}
