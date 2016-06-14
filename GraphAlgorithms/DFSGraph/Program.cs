using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension;
namespace DFSGraph
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

            input.Split('\n').ForEach(edgeString =>
            {
                var parts = edgeString.Split(' ');
                var v1 = int.Parse(parts[0]) - 1;
                var v2 = int.Parse(parts[1] )- 1;

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

            DFS(vertices, 0);


        }

        class Node
        {
            public  int Vertex{ get; set; }
            public int Level { get; set; }

        }

        private static void DFS(List<int>[] vertices, int v)
        {

            var start = new Node
            {
                Vertex = v,
                Level = 0
            };
            DFS(vertices, start, new HashSet<int>());
        }

        private static void DFS(List<int>[] vertices, Node v, HashSet<int> visited)
        {
            if (visited.Contains(v.Vertex))
            {
                return;
            }

            Console.WriteLine("{0}{1}", new string('-', v.Level), v.Vertex + 1);
            visited.Add(v.Vertex);
            vertices[v.Vertex].ForEach(neighbour =>
            {
                var next = new Node
                {
                    Vertex = neighbour,
                    Level = v.Level + 1
                };
                DFS(vertices, next, visited);

            });
        }
    }
}
