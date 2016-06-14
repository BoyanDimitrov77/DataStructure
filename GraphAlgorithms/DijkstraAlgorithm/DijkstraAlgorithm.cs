using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension;
namespace DijkstraAlgorithm
{
    class DijkstraAlgorithm
    {
        static string inputWeightedGraph = @"0 3 7
0 4 3
0 5 5
1 2 10
1 3 2
1 4 1
2 4 100
2 5 17
3 4 1 
4 5 3";
        static void Main(string[] args)
        {
            Dijkstra();
        }

        class WeigtedNode:IComparable<WeigtedNode>
        {

            public int Vertex{get;set;}
            public int Weight { get; set; }

            public WeigtedNode(int vertex,int weight)
            {
                Vertex = vertex;
                Weight = weight;
            }

            public int CompareTo(WeigtedNode other)
            {
                if (this.Weight.CompareTo(other.Weight) == 0)
                {
                    return this.Vertex.CompareTo(other.Vertex);
                };
                return this.Weight.CompareTo(other.Weight);
            }
        }

        private static void Dijkstra()
        {
            int v = 0;

            List<WeigtedNode>[] vertices= ReadInput(inputWeightedGraph);

            var visited = new HashSet<int>();
            var queue = new SortedSet<WeigtedNode>();
            int[] d = Enumerable.Repeat(int.MaxValue, vertices.Length).ToArray();

            
            d[v] = 0;
            var path = new int[vertices.Length];
            path[v] = -1;

            queue.Add(new WeigtedNode(v, 0));

            while (queue.Count>0)
            {
                var current = queue.Min;
                queue.Remove(current);
                visited.Add(current.Vertex);
               
                vertices[current.Vertex].ForEach(neighbour =>
                {
                    var currentD = d[neighbour.Vertex];
                    var newD = d[current.Vertex] + neighbour.Weight;

                    if (currentD > newD)
                    {
                        d[neighbour.Vertex] = newD;
                        queue.Add(new WeigtedNode(neighbour.Vertex, newD));
                        path[neighbour.Vertex] = current.Vertex;
                    }
                });

                while(queue.Count>0 && visited.Contains(queue.Min.Vertex))
                {
                    queue.Remove(queue.Min);
                }
            }

            d.ForEach((distanace, vertex) =>
            {
                Console.WriteLine("{0}-->{1}  trough {2}",vertex,distanace,path[vertex]);

            });


        }

        private static List<WeigtedNode>[] ReadInput(string inputWeightedGraph)
        {
            int n = 6;
            var vertices = new List<WeigtedNode>[n];

            inputWeightedGraph.Split('\n').ForEach(edge =>
            {
                var parts = edge.Split(' ');

                var v1 = int.Parse(parts[0]);
                var v2 = int.Parse(parts[1]);
                var w = int.Parse(parts[2]);


                if (vertices[v1] == null)
                {
                    vertices[v1] = new List<WeigtedNode>();
                }

                if (vertices[v2] == null)
                {
                    vertices[v2] = new List<WeigtedNode>();
                }

                vertices[v1].Add(new WeigtedNode(v2, w));
                vertices[v2].Add(new WeigtedNode(v1, w));

            });
            return vertices;

        }
    }
}
