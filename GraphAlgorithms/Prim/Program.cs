using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension;

namespace Prim
{
    class Program
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
            PrimAl();

        }


        class WeigtedNode : IComparable<WeigtedNode>
        {

            public int Vertex { get; set; }
            public int Weight { get; set; }

            public WeigtedNode(int vertex, int weight)
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

        class Edge:IComparable<Edge>
        {
            public int V1 { get; set; }
            public int V2 { get; set; }
            public int Weight { get; set; }

            public Edge(int v1,int v2,int weight)
            {
                this.V1 = v1;
                this.V2 = v2;
                this.Weight = weight;
            }

            public int CompareTo(Edge other)
            {
                if (this.Weight.CompareTo(other.Weight)==0)
                {
                    return (this.V1 * this.V2).CompareTo(other.V1 * other.V2);
                }
                return this.Weight.CompareTo(other.Weight);
            }
        }

        private static void PrimAl()
        {
            int v = 0;
            List<WeigtedNode>[] vertices = ReadInput(inputWeightedGraph);
            var queue = new SortedSet<Edge>();

            queue.Add(new Edge(-1,v,0));
            HashSet<Edge> tree = new HashSet<Edge>();
            HashSet<int> visited = new HashSet<int>();


            while (queue.Count > 0)
            {
                var bestEdge = queue.Min;
                queue.Remove(bestEdge);

                if (visited.Contains(bestEdge.V2))
                {
                    continue;
                }

                tree.Add(bestEdge);
                visited.Add(bestEdge.V2);

                vertices[bestEdge.V2].ForEach(neighbour =>
                {
                    if (visited.Contains(neighbour.Vertex))
                    {
                        return;
                    }
                    queue.Add(new Edge(bestEdge.V2, neighbour.Vertex,neighbour.Weight));
                });
            }

            tree.ForEach(edge =>
            {
                Console.WriteLine("{0}-{1}:  {2}",edge.V1,edge.V2,edge.Weight);

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
