using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension;

namespace Kruskal
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
            KruskalAl();
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

        class Edge : IComparable<Edge>
        {
            public int V1 { get; set; }
            public int V2 { get; set; }
            public int Weight { get; set; }

            public Edge(int v1, int v2, int weight)
            {
                this.V1 = v1;
                this.V2 = v2;
                this.Weight = weight;
            }

            public int CompareTo(Edge other)
            {
                if (this.Weight.CompareTo(other.Weight) == 0)
                {
                    return (this.V1 * this.V2).CompareTo(other.V1 * other.V2);
                }
                return this.Weight.CompareTo(other.Weight);
            }
        }

        private static void KruskalAl()
        {
            int v = 0;
            int n = 6;
            var edges = inputWeightedGraph.Split('\n').Select(edge =>
             {

                 var parts = edge.Split(' ');
                 return new Edge(int.Parse(parts[0]),
                                 int.Parse(parts[1]),
                                 int.Parse(parts[2]));


             }).OrderBy(edge => edge.Weight).ToList() ;

            var visited = new HashSet<int>();

            var root = new int[n];
            var tree = new HashSet<Edge>();

            int index = -1;

            while (index < edges.Count-1)
            {
                index++;
                var edge = edges[index];
                var v1 = edge.V1;
                var v2 = edge.V2;

                if(visited.Contains(v1) && visited.Contains(v2))
                {
                    if (root[v1] == root[v2])
                    {
                        continue;
                    }
                    var newRoot = root[v1];
                    var oldRoot = root[v2];

                    for (int i = 0; i < root.Length; i++)
                    {
                        if (root[i] == oldRoot)
                        {
                            root[i] = newRoot;
                        }
                      

                    }


                }else if (visited.Contains(v1))
                {
                    //v2 is not in a tree
                    root[v2] = root[v1];
                    tree.Add(edge);
                }else if (visited.Contains(v2))
                {
                    //v1 is not in a tree
                    root[v1] = root[v2];
                    tree.Add(edge);
                }
                else
                {
                    //build new tree
                    tree.Add(edge);
                    root[v1] = v1;
                    root[v2] = root[v1];
                }
                visited.Add(v1); 
                visited.Add(v2);
    
            }

            tree.ForEach(edge =>
            {
                Console.WriteLine("{0}-{1}:  {2}", edge.V1, edge.V2, edge.Weight);

            });
        }
       
       


        
    }
}
